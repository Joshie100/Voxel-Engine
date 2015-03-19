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

	public bool useForCol = false;

	// -----------------------------------------------

	public MeshData (){
	}

	// Adds a vertex to the list and also adds it to a collider if necessary
	public void AddVertex(Vector3 vertex)
	{
		vertices.Add (vertex);
		if (useForCol)
			colVertices.Add (vertex);

	}

	// Forms a quad from 2 triangles
	public void AddQuadTriangles()
	{
		triangles.Add (vertices.Count - 4);
		triangles.Add (vertices.Count - 3);
		triangles.Add (vertices.Count - 2);

		triangles.Add (vertices.Count - 4);
		triangles.Add (vertices.Count - 2);
		triangles.Add (vertices.Count - 1);
	}
}
