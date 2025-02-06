using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LE : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);

    }
}
