using System.Text;

namespace BMICalc
{
    public enum Category
    {
        Underweight,
        Normal,
        Overweight
    }
    internal class Person
    {
        private float mass;
        private float height;
        private float bmi;
        private Category category;

        public Person(float mass, float height)
        {
            this.Mass = mass;
            this.Height = height;
            this.Bmi = CalculateBMI(this);
            this.Category = CategorizeBMI(this);
        }

        public float Mass
        {
            get => mass;
            set => mass = value;
        }
        public float Height
        {
            get => height;
            set => height = value;
        }
        public float Bmi
        {
            get => bmi;
            set => bmi = value;
        }
        public Category Category
        {
            get => category;
            set => category = value;
        }

        public Category CategorizeBMI(Person p)
        {
            if (p.Bmi < 18.5)
            {
                return Category.Underweight;
            }
            else if (p.Bmi > 25.0)
            {
                return Category.Overweight;
            }
            else
            {
                return Category.Normal;
            }

        }

        public static float CalculateBMI(Person p)
        {
            return (float)(p.Mass / (Math.Pow((p.Height / 100f), 2)));
        }

        public string Stringify()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Person: { ")
                .Append("BMI: ")
                .Append(this.Bmi)
                .Append(' ')
                .Append("Category: ")
                .Append(this.Category)
                .Append(" }");
            return sb.ToString();
        }
    }
}