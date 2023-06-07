using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    WheelCollider[] wheelColliders;
    List<GameObject> wheelMesh= new List<GameObject>();
    public float torgue = 500;
    public float steerAngle = 15;
    public SteerType steerType;

    public DirtyLevelType dirtyLevel = DirtyLevelType.NoneDirt;
    GameObject carBody = null;
    Camera playerCamera = null;
    Vector3 cameraStartPosition = new Vector3();
    public Image boosterUI;

    //body mesh
    private GameObject noneDirtyBody;
    private GameObject halvDirtyBody;
    private GameObject fullDirtyBody;

    //wheels mesh
    private List<GameObject> nonDirtyWheels = new List<GameObject>();
    private List<GameObject> halfDirtyWheels = new List<GameObject>();
    private List<GameObject> fullDirtyWheels = new List<GameObject>();

    private Transform lookPoint;
    public int activeDirtLevel = 0;

    Gravity gravity;

    private void Awake()
    {
        Core.CheckPoint.currentCheckpointIndex = 0;
        carBody = this.transform.GetChild(0).gameObject;
        Core.PlayerDetails.playerCarBody = carBody;
        Core.PlayerDetails.player = this.gameObject;
        gravity = FindObjectOfType<Gravity>();

    }
    void OnEnable()
    {
        Core.CheckPoint.currentCheckpointIndex = 0;
    }
    void Start()
    {
        if (Core.PlayerDetails.audioPlayer != null)
        {
            Core.PlayerDetails.audioPlayer.playInGame();
        }

        //find dirt meshes
        noneDirtyBody = Core.PlayerDetails.playerCarBody.transform.Find("NoneDirty").gameObject;
        halvDirtyBody = Core.PlayerDetails.playerCarBody.transform.Find("HalfDirty").gameObject;
        fullDirtyBody = Core.PlayerDetails.playerCarBody.transform.Find("FullDirty").gameObject;

        //find look point
        lookPoint = Core.PlayerDetails.playerCarBody.transform.Find("LookPoint");

        //get all wheelcoliders
        wheelColliders = GetComponentsInChildren<WheelCollider>();
        //get all meshs
        MeshRenderer[] meshs = GetComponentsInChildren<MeshRenderer>();

        //get camera
        playerCamera = GetComponentInChildren<Camera>();
        cameraStartPosition = playerCamera.transform.localPosition;
        //unparent
        playerCamera.transform.parent = null;

        //find wheel meshs
        foreach (MeshRenderer renderer in meshs)
        {
            if (renderer.gameObject.transform.parent.name.Contains("Wheel"))
            {
                wheelMesh.Add(renderer.gameObject.transform.parent.gameObject);
            }
        }

        //find wheel meshes
        foreach (GameObject obj in wheelMesh)
        {
            nonDirtyWheels.Add(obj.transform.Find("NoneDirty").gameObject);
            halfDirtyWheels.Add(obj.transform.transform.Find("HalfDirty").gameObject);
            fullDirtyWheels.Add(obj.transform.transform.Find("FullDirty").gameObject);
        }

        //switch dirt
        changeDirtyLevel(dirtyLevel);

    }

    void Update()
    {

        if (steerType != Core.PlayerDetails.steerType)
        {
            Core.PlayerDetails.steerType = steerType;
        }
        //loop trogh wheelcoliders
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            //wheel control
            if (Core.PlayerDetails.steerType == SteerType.FrontWheelDrive && wheelColliders[i].gameObject.name.Contains("Front"))
            {
                wheelColliders[i].steerAngle = Input.GetAxis("Horizontal") * steerAngle;
            }
            else if (Core.PlayerDetails.steerType == SteerType.RearWheelDrive && wheelColliders[i].gameObject.name.Contains("Back"))
            {
                wheelColliders[i].steerAngle = Input.GetAxis("Horizontal") * steerAngle * -1;
            }
            else if (Core.PlayerDetails.steerType == SteerType.FourWheelDrive)
            {
                wheelColliders[i].steerAngle = Input.GetAxis("Horizontal") * steerAngle;
            }

            wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * torgue * Core.PlayerDetails.speed;

            if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                wheelColliders[i].brakeTorque = float.MaxValue;
                Core.PlayerDetails.playerCarBody.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                wheelColliders[i].brakeTorque = 0;
                Core.PlayerDetails.playerCarBody.GetComponent<Rigidbody>().isKinematic = false;
            }

            //apply to mesh
            wheelColliders[i].GetWorldPose(out Vector3 wheelPosition, out Quaternion wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }

        //fix rotation
        float rotateStep = 5;
        float rotateAngleLimit = 50;

        if (carBody.transform.eulerAngles.x >= rotateAngleLimit && carBody.transform.eulerAngles.x < 180)
        {
            carBody.transform.Rotate(-rotateStep, 0, 0);
        }
        if (carBody.transform.eulerAngles.x <= 360 - rotateAngleLimit && carBody.transform.eulerAngles.x >= 180)
        {
            carBody.transform.Rotate(rotateStep, 0, 0);
        }
        if (carBody.transform.eulerAngles.z >= rotateAngleLimit && carBody.transform.eulerAngles.z < 180)
        {
            carBody.transform.Rotate(0, 0, -rotateStep);
        }
        if (carBody.transform.eulerAngles.z <= 360 - rotateAngleLimit && carBody.transform.eulerAngles.z >= 180)
        {
            carBody.transform.Rotate(0, 0, rotateStep);
        }


        //add durantion
        if (Core.PlayerDetails.boosters.Count > 0)
        {
            foreach(Booster booster in Core.PlayerDetails.boosters)
            {
                Core.Time.CountUpTime(ref booster.currentDuration);
                if (booster.currentDuration >= booster.duration)
                {
                    Core.PlayerDetails.maxSpeed = 1;
                    Core.PlayerDetails.speed = 1;
                    Core.PlayerDetails.boosters.Remove(booster);

                    if (booster.typeOfBooster == BoosterType.SpeedBoster)
                    {
                        Core.PlayerDetails.SpeedBoosterOn = false;
                    }

                    boosterUI.gameObject.SetActive(false); // removes boostericon from UI// zannie
                    break;
                }
                
            }
        }

        //reset spawn
        if(Input.GetKeyUp(KeyCode.R) && Core.CheckPoint.currentCheckpointIndex != 0 || Input.GetKeyUp(KeyCode.Joystick1Button0) && Core.CheckPoint.currentCheckpointIndex != 0)
        {
            Core.CheckPoint.SpawnAtLastCheckpoint();
        }

    }
    void FixedUpdate()
    {
        if (playerCamera != null)
        {
            //convert local position to world position
            Vector3 cameraWorldPosition = carBody.transform.TransformPoint(0, cameraStartPosition.y, cameraStartPosition.z);
            //fix camera vibration
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraWorldPosition, Time.deltaTime * 4);
            //look at car
            playerCamera.transform.LookAt(lookPoint);
        }
    }
    public void changeDirtyLevel(DirtyLevelType dirtyLevel)
    {
        if (dirtyLevel == DirtyLevelType.NoneDirt)
        {
            this.dirtyLevel = DirtyLevelType.NoneDirt;
            noneDirtyBody.SetActive(true);
            halvDirtyBody.SetActive(false);
            fullDirtyBody.SetActive(false);
            foreach (GameObject obj in fullDirtyWheels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in halfDirtyWheels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in nonDirtyWheels)
            {
                obj.SetActive(true);
            }
        }
        else if (dirtyLevel == DirtyLevelType.HalfDirt)
        {
            this.dirtyLevel = DirtyLevelType.HalfDirt;
            noneDirtyBody.SetActive(false);
            halvDirtyBody.SetActive(true);
            fullDirtyBody.SetActive(false);
            foreach (GameObject obj in fullDirtyWheels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in halfDirtyWheels)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in nonDirtyWheels)
            {
                obj.SetActive(false);
            }
        }
        else if (dirtyLevel == DirtyLevelType.FullDirt)
        {
            this.dirtyLevel = DirtyLevelType.FullDirt;
            noneDirtyBody.SetActive(false);
            halvDirtyBody.SetActive(false);
            fullDirtyBody.SetActive(true);
            foreach (GameObject obj in fullDirtyWheels)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in halfDirtyWheels)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in nonDirtyWheels)
            {
                obj.SetActive(false);
            }
        }
    }
}
