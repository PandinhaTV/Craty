using System.Collections;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public GameObject[] cratePrefab;
    public int crateType;
    [SerializeField] float diff;
    [SerializeField] float secondSpawn = 1.0f;
    [SerializeField] int minTransX;
    [SerializeField] int maxTransX;
    [SerializeField] int minTransY;
    [SerializeField] int maxTransY;
    void Start()
    {
        StartCoroutine(CrateSpawn());
    }

    // Update is called once per frame
    IEnumerator CrateSpawn()
    {
        while (true)
        {
            
            var wanted = Random.Range(minTransX, maxTransX);
            var wantedY = Random.Range(minTransY, maxTransY);
            var position = new Vector3(wanted, wantedY);
            crateType = Random.Range(0, cratePrefab.Length);
            GameObject gameObject = Instantiate(cratePrefab[crateType], position, Quaternion.identity);

            yield return new WaitForSeconds(secondSpawn);
            
        }

    }

}
