using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObstacles : MonoBehaviour
{
    public GameObject[] ObstaclPrefabs;
    public GameObject LikePrefab;
    public GameObject LikeStorage,ObstaclesStorage;
    public GeneratingByPrefab FloorStorage;

    public int MinDistBetweenObstaclebyZ;
    public int MaxAddToZObsatncePos;
    public int GenerateLinebyX;

    private Vector3 _position;

	// Use this for initialization
	void Start ()
	{
        _position = Vector3.zero;
        StartCoroutine(WaitAsecond());
	}

    public void GenerateObstaclesAndLikesOnFloor()
    {
        var makeDistanceBeforeEndFloor = 30f;
        while (_position.z < FloorStorage.LastPos.z - makeDistanceBeforeEndFloor)
        {
            Transform curObstacl = RandomObstacl.GetComponent<Transform>();
            _position = ReturnRandomPosX(_position);
            _position = AddRandomPosZ(_position);
            _position = ReturnPosAtFloor(_position);
            Instantiate(curObstacl, _position + curObstacl.position, curObstacl.rotation, ObstaclesStorage.transform);
            _position = ReturnRandomPosX(_position);
            _position = AddRandomPosZ(_position);
            _position = ReturnPosAtFloor(_position);
            var regretcoin = Random.Range(1,2);
            if (regretcoin == 1)
                Instantiate(LikePrefab, _position + LikePrefab.transform.position, 
                    LikePrefab.transform.rotation, LikeStorage.transform);
        }

    }
    public void GenerateObstaclceAndLikeOnFloorFromPosition(Vector3 position)
    {
        _position = position;
        GenerateObstaclesAndLikesOnFloor();
    }
    public GameObject RandomObstacl
    {
        get
        {
            int randomElement = Random.Range(0, ObstaclPrefabs.Length);
            var selectedObj = ObstaclPrefabs[randomElement];
            return selectedObj;
        }
    }
    private Vector3 ReturnRandomPosX (Vector3 position)
    {
        var getPosition = position;
        var randomXpos = Random.Range(-GenerateLinebyX, GenerateLinebyX);
        getPosition = new Vector3(randomXpos,getPosition.y,getPosition.z);
        return getPosition;
    }

    private Vector3 AddRandomPosZ(Vector3 position)
    {
        var getPosition = position;
        var randomZpos = MinDistBetweenObstaclebyZ + Random.Range(0, MaxAddToZObsatncePos);
        getPosition = new Vector3(getPosition.x,getPosition.y,getPosition.z + randomZpos);
        return getPosition;
    }

    private Vector3 ReturnPosAtFloor(Vector3 curentPos)
    {
        RaycastHit hit;
        Vector3 positionAtFloor = Vector3.zero;
        if (Physics.Raycast(curentPos, Vector3.down, out hit, 500f))
            positionAtFloor = new Vector3(curentPos.x, hit.point.y, curentPos.z);
        return positionAtFloor;
    }

    IEnumerator WaitAsecond()
    {
        yield return new WaitForEndOfFrame();
        GenerateObstaclesAndLikesOnFloor();
    }
}
