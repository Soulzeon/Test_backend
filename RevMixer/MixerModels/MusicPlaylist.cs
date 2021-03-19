﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerModels
{
    public class MusicPlaylist
    {
        public int Id { get; set; }
        public int PlayListId { get; set; }

        public PlayList PlayList { get; set; }

        public UploadMusic UploadMusic { get; set; }

        public int MusicId { get; set; }
    }
}