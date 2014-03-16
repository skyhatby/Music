using System;
using System.IO;

namespace MusicPlayer
{
    public class EntityId
    {
        public Guid Id { get; protected set; }

        protected string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 256) throw new InvalidDataException("Length must be less that 256");
                _name = value;
            }
        }
    }
}