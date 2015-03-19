using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour {

	// Created by Jozef Tokarcik
	// This class is responsible for hnadling operations within a chunk

	// --------------------- VARS -----------
	Block[ , ,] blocks;
	public static int chunkSize = 16;
	public bool update = true;
	// --------------------------------------

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Block GetBlock(int x, int y, int z)
	{
		return blocks[x, y, z];
	}

	// Updates the MeshData of the chunk
	void UpdateChunk()
	{

	}

	// Renders the MeshData of the chunk
	void RenderChunk()
	{

	}
}
