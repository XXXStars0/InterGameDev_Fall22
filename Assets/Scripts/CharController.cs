using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharController : MonoBehaviour
{
    private float x, y;
    private bool isWalking;

    public float walkingSpeed;
    private Animator a;
    public AudioSource walkSE;
    public CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        a = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Teleport();
        camAdjust();
    }

    void Moving()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        a.SetFloat("X", x);
        a.SetFloat("Y", y);
        if (x != 0 || y != 0)
        {
            if (!walkSE.isPlaying)
            {
                walkSE.Play();
            }
            
            this.GetComponent<Transform>().Translate(x * Time.deltaTime * walkingSpeed, y * Time.deltaTime * walkingSpeed, 0);
        }
        else
        {
            walkSE.Stop();
        }
    }

    void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("!");
            this.GetComponent<Transform>().position= new Vector3(0,0,0);
        }
    }

    void camAdjust()
    {
        if (Input.GetKeyUp(KeyCode.Q)&& cam.m_Lens.OrthographicSize>1)
        {
            cam.m_Lens.OrthographicSize -=1;
        }
        if (Input.GetKeyUp(KeyCode.E) && cam.m_Lens.OrthographicSize <10)
        {
            cam.m_Lens.OrthographicSize += 1;
        }
    }
}
