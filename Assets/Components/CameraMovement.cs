
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    
    // Declare a static instance variable to hold the singleton instance
    private static CameraMovement _instance;

    // Declare a public property to access the singleton instance
    public static CameraMovement Instance
    {
        get { return _instance; }
    }

    // Your existing variables and methods go here...

    private void Awake()
    {
        // Check if an instance already exists
        if (_instance == null)
        {
            // If not, set the instance to this object
            _instance = this;
            // Make sure the object persists between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, -10);
    }

    // Rest of your existing code...
}