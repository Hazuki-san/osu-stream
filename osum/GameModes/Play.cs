//  Play.cs
//  Author: Dean Herbert <pe@ppy.sh>
//  Copyright (c) 2010 2010 Dean Herbert
using System;
using osum.GameplayElements;
using osum.GameplayElements.Beatmaps;
using osum.Helpers;

namespace osum.GameModes

{
    public class Play : GameMode
    {
        HitObjectManager hitObjectManager;

        public Play() : base()
        {
            InputManager.OnDown += new InputHandler(InputManager_OnDown);
        }

        void InputManager_OnDown(InputSource source, TrackingPoint point)
        {
            //check with the hitObjectManager for a relevant hitObject...
            HitObject found = hitObjectManager.FindObjectAt(point);

            if (found != null)
                found.Hit();
        }

        internal override void Initialize()
        {
            Beatmap beatmap = new Beatmap("Beatmaps/bcl/");

            hitObjectManager = new HitObjectManager(beatmap);
            hitObjectManager.LoadFile();

            GameBase.Instance.backgroundAudioPlayer.Load("Beatmaps/bcl/babycruisingedit.mp3");
            GameBase.Instance.backgroundAudioPlayer.Play();
        }

        public override void Dispose()
        {
            InputManager.OnDown -= new InputHandler(InputManager_OnDown);

            hitObjectManager.Dispose();

            base.Dispose();
        }

        public override void Draw()
        {
            hitObjectManager.Draw();

            base.Draw();
        }

        public override void Update()
        {
            hitObjectManager.Update();

            base.Update();
        }
        
        
    }
}

