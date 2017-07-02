using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessController : MonoBehaviour
{
    public GeneratingByPrefab FloorContainer, LeftLensCountainer, RightLensCountainer;
    public AllObstacles AllObstacles;

    private Transform _player;
    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_player.position, FloorContainer.LastPos) < 250)
            NewPartGeneration();
    }

    public void NewPartGeneration()
    {
        var startGeneratePos = FloorContainer.LastPos;
        FloorContainer.LineOfObjectGeneratorFromObjCounttimes(FloorContainer.LastObj, 20);
        LeftLensCountainer.LineOfObjectGeneratorFromObjCounttimes(LeftLensCountainer.LastObj, 162);
        RightLensCountainer.LineOfObjectGeneratorFromObjCounttimes(RightLensCountainer.LastObj, 162);
        AllObstacles.GenerateObstaclceAndLikeOnFloorFromPosition(startGeneratePos);
    }
}
