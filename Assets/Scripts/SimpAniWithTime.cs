using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpAniWithTime : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public int interval_time = 3;

    private SpriteRenderer s;
    private int playtime;
    // Start is called before the first frame update
    void Start()
    {
        s = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playtime=(int)(Mathf.Floor(Time.time));
        switch (playtime/interval_time%3)
        {
            case 0:
                s.sprite = frame1;
                break;
            case 1:
                s.sprite = frame2;
                break;
            case 2:
                s.sprite = frame3;
                break;
            default:
                s.sprite = frame1;
                break;
        }
    }
}
