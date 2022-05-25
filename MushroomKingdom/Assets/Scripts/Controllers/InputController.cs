using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Camera c;
    int rayDistance = 300;
    public GameObject shroomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            //Remove spawned prefab when holding left shift and left clicking
            Transform selectedTransform = GetObjectOnClick();
            if (selectedTransform)
            {
                selectedTransform.gameObject.GetComponent<MushroomActions>().Explode();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //On left click spawn selected prefab and align its rotation to a surface normal
            Vector3[] spawnData = GetClickPositionAndNormal();
            if(spawnData[0] != Vector3.zero)
            {
                Instantiate(shroomPrefab, spawnData[0], Quaternion.FromToRotation(shroomPrefab.transform.up, spawnData[1]));
            }
        }
    }

    Vector3[] GetClickPositionAndNormal()
    {
        Vector3[] returnData = new Vector3[] { Vector3.zero, Vector3.zero }; //0 = spawn poisiton, 1 = surface normal
        Ray ray = c.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            returnData[0] = hit.point;
            returnData[1] = hit.normal;
        }

        return returnData;
    }

    Transform GetObjectOnClick()
    {
        Ray ray = c.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Transform root = hit.transform.root;
            if (root.CompareTag("ExplodingShroom"))
            {
                return root;
            }
        }

        return null;
    }
}
