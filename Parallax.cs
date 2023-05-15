using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float speed = 1f;

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
