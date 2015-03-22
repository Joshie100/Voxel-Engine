using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public Dictionary<WorldPos, Chunk> chunks = new Dictionary<WorldPos, Chunk>();

	public GameObject chunkPreFab;



	// Use this for initialization
	void Start () {

		for (int x = 0; x < 4; x++)
			for (int y = 0; y < 4; y++)
				for (int z = 0; z < 4; z++) {
				CreateChunk(x * 16, y * 16, z * 16);
				}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// This function creates a chunk
	public void CreateChunk(int x, int y, int z)
	{
		WorldPos worldPos = new WorldPos (x, y, z);

		GameObject chunk = Instantiate (chunkPreFab, new Vector3 (x, y, z), Quaternion.identity) as GameObject;

		Chunk theChunk = chunk.GetComponent<Chunk> ();

		theChunk.pos = worldPos;
		theChunk.world = this;

		chunks.Add (worldPos, theChunk);

		// TEMP TEST CODE

		for (int xi = 0; xi < 16; xi++) {
			for(int yi = 0; yi < 16; yi++)
			{
				for (int zi = 0; zi < 16; zi++)
				{
					if(yi <= 7)
					{
						SetBlock(x + xi, y + yi, z + zi, new BlockGrass());
					}
					else
					{
						SetBlock(x + xi, y + yi, z + zi, new BlockAir());
					}
				}
			}
		}
	}

	// This function returns a target chunk
	public Chunk GetChunk(int x, int y, int z)
	{
		WorldPos pos = new WorldPos ();
		float multiple = Chunk.chunkSize;

		pos.x = Mathf.FloorToInt (x / multiple) * Chunk.chunkSize;
		pos.y = Mathf.FloorToInt (y / multiple) * Chunk.chunkSize;
		pos.z = Mathf.FloorToInt (z / multiple) * Chunk.chunkSize;

		Chunk container = null;

		chunks.TryGetValue (pos, out container);

		return container;
	}

	// This function returns a target block
	public Block GetBlock(int x, int y, int z)
	{
		Chunk container = GetChunk(x, y, z);

		if (container != null) {
			Block block = container.GetBlock (x - container.pos.x,
			                                 y - container.pos.y,
			                                 z - container.pos.z);
			return block;
		} else {
			return new BlockAir();
		}

	}

	// This function sets a target block
	public void SetBlock(int x, int y, int z, Block block)
	{
		Chunk container = GetChunk (x, y, z);

		if (container != null) {
			container.SetBlock(x - container.pos.x, y - container.pos.y, z - container.pos.z, block);
			container.update = true;
		}
	}
}
