﻿using System;

namespace CocosSharp
{

    internal class CCBatchCommand : CCRenderCommand
    {
        #region Properties

        internal CCTextureAtlas TextureAtlas { get; private set; }
        internal CCBlendFunc BlendType { get; private set; }

        #endregion Properties


        #region Constructors

        public CCBatchCommand(float globalZOrder, CCAffineTransform worldTransform, CCBlendFunc blendType, CCTextureAtlas textureAtlas) 
            : base(globalZOrder, worldTransform)
        {
            TextureAtlas = textureAtlas;
            BlendType = blendType;
        }

        #endregion Constructors


        internal void RenderBatch(CCDrawManager drawManager)
        {
            drawManager.BindTexture(TextureAtlas.Texture);
            drawManager.BlendFunc(BlendType);
            TextureAtlas.DrawQuads();
        }

        internal override void RequestRenderCommand(CCRenderer renderer)
        {
            renderer.ProcessBatchRenderCommand(this);
        }
    }
}

