using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

using Random = UnityEngine.Random;

public enum ChunkDifficulty{Easy, Normal, Hard}

public class Chunk : IDisposable
{
    private Vector3 position;
    public Vector3 Position
    {
        set
        {
            position = value;
            Seed = position.magnitude;
            Difficulty = (ChunkDifficulty)(int)(position.magnitude/MapSize * Random.value);
        }
        get{return position;}
    }
    public float Seed;
    public ChunkDifficulty Difficulty;
    const int MapSize = 1000; 
    public Chunk()
    {
        position = Vector3.zero;
    }
    public void Spawn ()
    {
        // Seed를 이용해서 spawn
        return;
    }

    /// <summary>
    /// Global Position을 Chunk의 Local Position으로 변환해줍니다.
    /// </summary>
    public Vector3 LocalPos (Vector3 globalPos)
    {
        return globalPos - position + 
                new Vector3(ChunkManager.Instance.Width*1/2, ChunkManager.Instance.Height*1/2, 0);
    }
    /// <summary>
    /// Chunk의 Local Position을 Global Position으로 변환해줍니다.
    /// </summary>
    public Vector3 GlobalPos (Vector3 localPos)
    {
        return localPos + position - 
                new Vector3(ChunkManager.Instance.Width*1/2, ChunkManager.Instance.Height*1/2, 0);
    }

    void IDisposable.Dispose()
    {
        position = Vector3.zero;
    }

}

