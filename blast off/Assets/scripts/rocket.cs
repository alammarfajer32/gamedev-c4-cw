using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{

    Rigidbody rocketRB;
    AudioSource rocketAudioSource;

    [SerializeField] AudioClip mainEngine;
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
            rocketRB.AddRelativeForce(Vector3.up * 60);
            if (!rocketAudioSource.isPlaying)
            {
                rocketAudioSource.PlayOneShot(mainEngine);
            }
        } else
        {
            rocketAudioSource.Stop();
        }
    }
    void Rotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            print("Rotating left");
            transform.Rotate(Vector3.forward);
        }else if (Input.GetKey(KeyCode.D)) {
            print("Rotating right");
            transform.Rotate(-Vector3.forward);
        }
    }
}
