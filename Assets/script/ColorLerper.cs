using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{

    public Material WhiteMaterial;
    public Material DarkBlackMaterial;
    public GameObject Object;

    void OnCollisionEnter(Collision Current)
    {
        var renderer = Object.GetComponent<MeshRenderer>();
        Material[] materials = renderer.sharedMaterials; // read current array of materials
        materials[0] = WhiteMaterial;
        renderer.sharedMaterials = materials; // assign the array back to the property to actually apply the changes
    }
}
