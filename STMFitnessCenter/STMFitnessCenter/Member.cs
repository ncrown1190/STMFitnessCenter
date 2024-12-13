﻿namespace STMFitnessCenter
{
    public abstract class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Member(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public abstract void CheckIn(Club club);


    }
}
