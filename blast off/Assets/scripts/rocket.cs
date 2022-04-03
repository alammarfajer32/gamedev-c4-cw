using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{

    Rigidbody rocketRB;
    AudioSource rocketAudioSource;
    //SerialixeFields
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float thrustSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("update");
        Thrust();
        Rotate();
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Thrusting");
            rocketRB.AddRelativeForce(Vector3.up * thrustSpeed);
            if (!rocketAudioSource.isPlaying)
            {
                rocketAudioSource.PlayOneShot(mainEngine);
            }
        } else
        {
            rocketAudioSource.Stop();
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("No problem");
                break;
            case "Finish":
                print("You win!");
                SceneManager.LoadScene("lvl2");
                break;
                default:
                print("You lose!");
                SceneManager.LoadScene("lvl1");
                break;
        }
    }


    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


    void Rotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //print("Rotating left");
            transform.Rotate(Vector3.forward *rotationSpeed);
        }else if (Input.GetKey(KeyCode.D)) {
            //print("Rotating right");
            transform.Rotate(-Vector3.forward *rotationSpeed);
        }
    }
}
