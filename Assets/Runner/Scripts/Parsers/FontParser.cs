﻿//  
// Copyright (c) Jesse Freeman. All rights reserved.  
// 
// Licensed under the Microsoft Public License (MS-PL) License. 
// See LICENSE file in the project root for full license information. 
// 
// Contributors
// --------------------------------------------------------
// This is the official list of Pixel Vision 8 contributors:
//  
// Jesse Freeman - @JesseFreeman
// Christer Kaitila - @McFunkypants
// Pedro Medeiros - @saint11
// Shawn Rakowski - @shwany
// 

//using PixelVisionSDK.Chips;
using UnityEngine;
using PixelVisionSDK.Chips;
using FontChip = PixelVision8.Chips.FontChip;

namespace PixelVisionRunner.Parsers
{

    public class FontParser: SpriteParser
    {

        private FontChip fontChip;
        private bool autoImport;
        private int[] fontMap;
        private string name;

        public FontParser(Texture2D tex, IEngineChips chips, string name = "Default", bool autoImport = true) : base(tex, chips)
        {
            this.fontChip = chips.fontChip as FontChip;
            if (fontChip == null)
            {
                // Create a new color map chip to store data
                fontChip = new FontChip();
                chips.chipManager.ActivateChip(fontChip.GetType().FullName, fontChip);
            }
            this.autoImport = autoImport;
            this.name = name;
        }

        public override void CutOutSprites()
        {
            fontMap = new int[totalSprites];

            base.CutOutSprites();

            fontChip.AddFont(name, fontMap);
        }

        public override bool IsEmpty(Color[] pixels)
        {
            // Hack to make sure if the space is empty we still save it
            if (index == 0)
                return false;

            return base.IsEmpty(pixels);
        }

        protected override void ProcessSpriteData()
        {
            var id = spriteChip.FindSprite(spriteData);

            if (id == -1 && autoImport)
            {
                id = spriteChip.NextEmptyID();
                spriteChip.UpdateSpriteAt(id, spriteData);
            }

            fontMap[index] = id;
        }

    }

}