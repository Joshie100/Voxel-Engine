using UnityEngine;
using System.Collections;

public class BlockGrass : Block {
	public BlockGrass() 
	:base() {

	}

	public override bool isSolid (Direction direction)
	{
		return true;
	}

	public override Tile TexturePosition (Direction direction)
	{
		Tile tile = new Tile ();
		switch (direction) {
		case Direction.Down:
			tile.x = 2;
			tile.y = 15;
			return tile;
		case Direction.Up:
			tile.x = 0;
			tile.y = 15;
			return tile;

		}
		tile.x = 3;
		tile.y = 15;
		return tile;
	}


}
