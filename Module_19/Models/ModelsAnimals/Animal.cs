namespace Module_19
{
    public partial class Animal : IAnimal
    {
        public int Id { get; set; }
        public string TypeAnimal { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public double Weight { get; set; }

        public Animal(string typeAnimal, string name, double age, double weight)
        {
            TypeAnimal = typeAnimal;
            Name = name;
            Age = age;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Id} {TypeAnimal} {Name} {Age} {Weight};";
        }
    }
}
