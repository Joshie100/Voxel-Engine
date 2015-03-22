using UnityEngine;
using System.Collections;

public struct WorldPos {

	// Created by Jozef Tokarcik
	// Holds information about a position in a world

	public int x;
	public int y;
	public int z;

	public WorldPos(int px, int py, int pz)
	{
		x = px;
		y = py;
		z = pz;
	}

	// This function optimizes the speed of == operator
	public override bool Equals(object obj)
	{
		if (!(obj is WorldPos))
			return false;
		
		WorldPos pos = (WorldPos)obj;
		if (pos.x != x || pos.y != y || pos.z != z)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}

