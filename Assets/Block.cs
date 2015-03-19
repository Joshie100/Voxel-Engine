using UnityEngine;
using System.Collections;

public class Block {

	// Created By Jozef Tokarcik
	// This class is a framework for all blocks

	// ----------------- VARS -----------------
	public enum Direction
	{
		North, South, Up, Down, West, East
	};
	// ---------------------------------------
	

	public Block() {
	}

	// This functions returns if a block is solid in the specified direction
	public virtual bool isSolid(Direction direction)
	{
		return true;
	}

	// This function builds MeshData of a block
	public virtual MeshData BlockData(Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		meshData.useForCol = true;
		if (!chunk.GetBlock (x, y + 1, z).isSolid (Direction.Down)) {
			meshData = FaceDataUp(x, y, z, meshData);
		}

		if (!chunk.GetBlock (x, y - 1, z).isSolid (Direction.Up)) {
			meshData = FaceDataDown(x, y, z, meshData);
		}

		if (!chunk.GetBlock (x - 1, y, z).isSolid (Direction.East)) {
			meshData = FaceDataWest(x, y, z, meshData);
		}

		if (!chunk.GetBlock (x + 1, y, z).isSolid (Direction.West)) {
			meshData = FaceDataEast(x, y, z, meshData);
		}

		if (!chunk.GetBlock (x, y, z - 1).isSolid (Direction.North)) {
			meshData = FaceDataSouth(x, y, z, meshData);
		}

		if (!chunk.GetBlock (x, y, z + 1).isSolid (Direction.South)) {
			meshData = FaceDataNorth(x, y, z, meshData);
		}

		return meshData;
	}


	// The following functions build each face of a vertex
	public virtual MeshData FaceDataUp(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}

	public virtual MeshData FaceDataDown(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}

	public virtual MeshData FaceDataNorth(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}
	
	public virtual MeshData FaceDataSouth(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}

	public virtual MeshData FaceDataWest(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x - 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}
	
	public virtual MeshData FaceDataEast(int x, int y, int z, MeshData meshData)
	{
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z - 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y + 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z + 0.5f));
		meshData.AddVertex (new Vector3 (x + 0.5f, y - 0.5f, z - 0.5f));
		meshData.AddQuadTriangles ();
		return meshData;
	}



}
