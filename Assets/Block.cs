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
		return false;
	}

	// This function builds MeshData of a block
	public virtual MeshData BlockData(Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		if (!chunk.GetBlock (x, y + 1, z).isSolid (Direction.Down)) {
			meshData = FaceDataUp(meshData);
		}

		if (!chunk.GetBlock (x, y - 1, z).isSolid (Direction.Up)) {
			meshData = FaceDataDown(meshData);
		}

		if (!chunk.GetBlock (x - 1, y, z).isSolid (Direction.East)) {
			meshData = FaceDataWest(meshData);
		}

		if (!chunk.GetBlock (x + 1, y, z).isSolid (Direction.West)) {
			meshData = FaceDataEast(meshData);
		}

		if (!chunk.GetBlock (x, y, z - 1).isSolid (Direction.North)) {
			meshData = FaceDataSouth(meshData);
		}

		if (!chunk.GetBlock (x, y, z + 1).isSolid (Direction.South)) {
			meshData = FaceDataNorth(meshData);
		}

		return meshData;
	}


	// The following functions build each face of a vertex
	public virtual MeshData FaceDataNorth(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}

	public virtual MeshData FaceDataSouth(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}

	public virtual MeshData FaceDataUp(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}
	
	public virtual MeshData FaceDataDown(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}

	public virtual MeshData FaceDataWest(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}
	
	public virtual MeshData FaceDataEast(int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}



}
