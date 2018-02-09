﻿using PixelVisionSDK.Chips;

public class MusicDemoGameChip : GameChip
{

	public override void Init()
	{

		//set the background color to black
		BackgroundColor(32);

		// display instruction text for playing thesound
		DrawText("Music Demo", 1, 1, DrawMode.Tile, "large-font");
		DrawText("Click anywhere to play!", 1, 4, DrawMode.Tile, "large-font", 1);

	}

	public override void Update(float timeDelta)
	{
		base.Update(timeDelta);
		
		//get if the mouse is down
		var mouseDown = MouseButton(0, InputState.Released);

		// if mouse is down, play the first sound sfx
		if (mouseDown)
		{
			// play the first sound id in the first channel
			PlaySong(new[] {0}, false);
			
		}

	}

	public override void Draw()
	{
		Clear();
		DrawTilemap();
	}
}