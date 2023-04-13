using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public GameObject book_Prefab;
    
    public void SpawnBook()
    {
        GameObject book_Obj = Instantiate(book_Prefab);

        Vector3 temp = transform.position;
        temp.z = 0f;

        book_Obj.transform.position = temp;
    }
}
