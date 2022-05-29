using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo
{
    static class Sound
    {
        private static Song music;
        public static SoundEffect win, end, start;
        public static Song Music
        {
            get
            {
                return music;
            }
            private set
            {

            }
        }

        // a random object for generating random numbers for calling a random sound from a list
        private static readonly Random rand = new Random();

        // an array of shot sounds

        private const int numberOfShotSounds = 2;
        private static SoundEffect[] shots;
        // get a random shot sound from the list of shot sounds
        public static SoundEffect Shot
        {
            get
            {
                return shots[rand.Next(shots.Length)];
            }
        }


        // the load method to be called in the main game class under it's load method
        public static void Load(ContentManager content)
        {
             //load up the music
          music = content.Load<Song>("Sound\\music");


            // load all the shot sounds to the shots array
            shots = new SoundEffect[numberOfShotSounds];

            for (int i = 0; i < numberOfShotSounds; i++)
            {
                shots[i] = content.Load<SoundEffect>(string.Format("Sound\\laser{0}", i + 1));
            }
            // load all the spawn sounds to the spawns array
            win = content.Load<SoundEffect>("Sound\\win");
            end = content.Load<SoundEffect>("Sound\\end");
            start = content.Load<SoundEffect>("Sound\\start");

        }
    }
}
