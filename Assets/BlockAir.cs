using UnityEngine;
using System.Collections;

public class BlockAir : Block {

	// Created by Jozef Tokarcik
	// This is the "Air Block"

	public BlockAir() 
	: base()
	{
	}

	public override MeshData BlockData (Chunk chunk, int x, int y, int z, MeshData meshData)
	{
		return meshData;
	}

	public override bool isSolid (Direction direction)
	{
		return false;
	}
}
