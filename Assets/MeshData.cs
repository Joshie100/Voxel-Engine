using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData {

	// Created By Jozef Tokarcik
	// This class is responsible for holding all the chunk render information

	//------------- VARS ----------------------------

	public List<Vector3> vertices = new List<Vector3>();
	public List<int> triangles = new List<int>();
	public List<Vector2> uv = new List<Vector2>();

	public List<Vector3> colVertices = new List<Vector3>();
	public List<int> colTriangles = new List<int>();

	// -----------------------------------------------

	public MeshData (){
	}

	// Adds a vertex to the list and also adds it to a collider if necessary
	void AddVertex(Vector3 vertex, bool useForCol)
	{
		vertices.Add (vertex);
		if (useForCol)
			colVertices.Add (vertex);

	}
}
