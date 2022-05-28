using System.Linq;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Camera c;
    int rayDistance = 300;
    public GameObject shroomPrefab;
    [SerializeField] private GameObject shroomSuperPrefab;
    [SerializeField] private float corpseRange = 3.0f;

    public GameObject heroShroom;

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
            Ray ray = c.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            // return if ray fails
            if (!Physics.Raycast(ray, out hit, rayDistance))
                return;

            // return if click lands on something other than ground
            if (!hit.transform.CompareTag("Ground"))
                return;

            //On left click spawn selected prefab and align its rotation to a surface normal
            Vector3[] spawnData = GetClickPositionAndNormal(hit);


            if(spawnData[0] != Vector3.zero && heroShroom.GetComponent<HeroMushroom>().CurrentEnergy >= 5.0f)
            {
                // Find any ant corpses around the spawn point
                GameObject[] nearCorpses = GetSurroundingAntCorpses(spawnData[0]);

                if (nearCorpses.Length > 0)
                {
                    // Spawn super shroom prefab
                    GameObject shroom = Instantiate(shroomSuperPrefab, spawnData[0], Quaternion.FromToRotation(shroomPrefab.transform.up, spawnData[1]));
                    shroom.transform.RotateAround(spawnData[0], spawnData[1], Random.Range(0, 360));
                    heroShroom.GetComponent<HeroMushroom>().ShroomSpawned();

                    // Remove all used corpses
                    foreach(GameObject corpse in nearCorpses)
                    {
                        corpse.GetComponent<AntCorpseActions>().RemoveCorpse();
                    }
                }
                else
                {
                    GameObject shroom = Instantiate(shroomPrefab, spawnData[0], Quaternion.FromToRotation(shroomPrefab.transform.up, spawnData[1]));
                    shroom.transform.RotateAround(spawnData[0], spawnData[1], Random.Range(0, 360));
                    heroShroom.GetComponent<HeroMushroom>().ShroomSpawned();
                }
            }
        }
    }

    Vector3[] GetClickPositionAndNormal(RaycastHit hit)
    {
        Vector3[] returnData = new Vector3[] { Vector3.zero, Vector3.zero }; //0 = spawn poisiton, 1 = surface normal

        returnData[0] = hit.point;
        returnData[1] = hit.normal;

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

    private GameObject[] GetSurroundingAntCorpses(Vector3 centre)
    {
        Collider[] hitColliders = Physics.OverlapSphere(centre, corpseRange);
        return hitColliders.Where(hc => hc.gameObject.CompareTag("AntCorpse")).Select(hc => hc.gameObject).ToArray();
    }
}
