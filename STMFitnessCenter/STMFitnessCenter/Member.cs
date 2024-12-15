namespace STMFitnessCenter
{
    public abstract class Member
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }

        public Member(string name)
        {
            Id = nextId++;
            Name = name;
        }
        public abstract void CheckIn(Club club);
    }
}
