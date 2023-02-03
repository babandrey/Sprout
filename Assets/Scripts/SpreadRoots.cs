using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadRoots : MonoBehaviour
{
    public Tile rootTile;
    public Tilemap rootTilemap;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos = this.transform.position + new Vector3(0,-100,0);
        StartCoroutine(Move(targetPos));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        Vector3Int currentCell = rootTilemap.WorldToCell(transform.position);
        rootTilemap.SetTile(currentCell, rootTile);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        Vector3 nextStep = this.transform.position + new Vector3(0,-5,0);
        while(IsWalkabale(nextStep) && (targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);
            nextStep = this.transform.position + new Vector3(0,-1,0);
            yield return null;
        }
    }

    private bool IsWalkabale(Vector3 targetPos)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPos, 0.2f);

        foreach(Collider2D collider in colliders)
        {
            if(!collider.isTrigger)
            {
                Debug.Log("Collided!");
                return false;
            }
            else
            {
                Debug.Log("Clear: " + targetPos.x +" " + targetPos.y + " " + targetPos.z);
            }
        }

        return true;
    }
}
