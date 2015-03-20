using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Chunk : MonoBehaviour {

	// Created by Jozef Tokarcik
	// This class is responsible for hnadling operations within a chunk

	// --------------------- VARS -----------
	Block[ , ,] blocks = new Block[chunkSize, chunkSize, chunkSize];
	public static int chunkSize = 16;
	public bool update = true;
	MeshCollider col;
	MeshFilter filter;
	// --------------------------------------

	// Use this for initialization
	void Start () {
		col = GetComponent<MeshCollider> ();
		filter = GetComponent<MeshFilter> ();

		for (int x = 0; x < chunkSize; x++)
			for (int y = 0; y < chunkSize; y++)
				for (int z = 0; z < chunkSize; z++) {
				blocks[x, y, z] = new BlockAir();
				}
		blocks [3, 5, 2] = new Block ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (update == true)
			UpdateChunk();
	
	}
	// Returns the block at that direction
	public Block GetBlock(int x, int y, int z)
	{
		if(IsInRange(x) && IsInRange(y) && IsInRange(z))
			return blocks[x, y, z];
		return new BlockAir ();
	}

	// Updates the MeshData of the chunk
	void UpdateChunk()
	{
		MeshData meshData = new MeshData ();
		for (int x = 0; x < chunkSize; x++)
			for (int y = 0; y < chunkSize; y++)
				for (int z = 0; z < chunkSize; z++) {
				meshData = blocks[x, y, z].BlockData(this, x, y, z, meshData);
				}
		RenderChunk (meshData);
	}

	// Renders the MeshData of the chunk
	void RenderChunk(MeshData meshData)
	{
		filter.mesh.Clear ();
		filter.mesh.vertices = meshData.vertices.ToArray ();
		filter.mesh.triangles = meshData.triangles.ToArray ();

		col.sharedMesh = null;
		Mesh mesh = new Mesh ();
		mesh.vertices = meshData.colVertices.ToArray ();
		mesh.triangles = meshData.colTriangles.ToArray ();
		col.sharedMesh = mesh;

		filter.mesh.Optimize ();
		filter.mesh.RecalculateNormals ();
	}
	// Decides if the index is in range
	bool IsInRange (int index)
	{
		if (index < chunkSize && index >= 0)
			return true;
		return false;
	}
}
