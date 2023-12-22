using UnityEngine;
using System.Collections;

public class ItemDropper : MonoBehaviour
{
    public GameObject[] itemsToDrop;
    public Vector3 areaSize;
    public Vector3 areaCenter;
    public float dropHeight = 10.0f;
    public float dropRate = 1.0f;

    void Start()
    {
        StartCoroutine(DropItems());
    }

    IEnumerator DropItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(dropRate);

            Vector3 dropPosition = areaCenter + new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                dropHeight,
                Random.Range(-areaSize.z / 2, areaSize.z / 2));

            int itemIndex = Random.Range(0, itemsToDrop.Length);
            Instantiate(itemsToDrop[itemIndex], dropPosition, Quaternion.identity);
        }
    }

}