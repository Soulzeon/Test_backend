﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class PlayList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        //this table specifies what uploaded music belongs to that playlist - apologies if it's a little confusing
        //to retrieve music through eager loading with ef core and our context, we will need to use an include(), then a thenInclude() to drill down
        public ICollection<MusicPlaylist> MusicPlaylist { get; set; }

        public User User { get; set; }


    }
}