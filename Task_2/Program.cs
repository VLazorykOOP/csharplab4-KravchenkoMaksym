using System;


namespace Task_2
{
    using System;

    public class VectorDouble
    {
        protected double[] FArray;
        protected uint num;
        protected int codeError;
        protected static uint num_vd;

        public VectorDouble()
        {
            FArray = new double[1];
            num = 1;
            codeError = 0;
            num_vd++;
        }

        public VectorDouble(uint size)
        {
            FArray = new double[size];
            num = size;
            codeError = 0;
            num_vd++;
        }

        public VectorDouble(uint size, double initValue)
        {
            FArray = new double[size];
            for (int i = 0; i < size; i++)
            {
                FArray[i] = initValue;
            }
            num = size;
            codeError = 0;
            num_vd++;
        }

        ~VectorDouble()
        {
            Console.WriteLine("VectorDouble object has been destroyed.");
            num_vd--;
        }

        public void InputElements()
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write("Enter element {0}: ", i);
                FArray[i] = Convert.ToDouble(Console.ReadLine());
            }
        }

        public void DisplayElements()
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Element {0}: {1}", i, FArray[i]);
            }
        }

        public void AssignValue(double value)
        {
            for (int i = 0; i < num; i++)
            {
                FArray[i] = value;
            }
        }

        public static uint GetNumVectors()
        {
            return num_vd;
        }

        public uint Size
        {
            get { return num; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < num)
                {
                    return FArray[index];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index >= 0 && index < num)
                {
                    FArray[index] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }

        // Overloading operators and other methods will go here.
    }

    class Program
    {
        static void Main(string[] args)
        {
            VectorDouble vector1 = new VectorDouble(5, 2.0);
            VectorDouble vector2 = new VectorDouble(3, 3.0);

            Console.WriteLine("Vector 1 elements:");
            vector1.DisplayElements();

            Console.WriteLine("Vector 2 elements:");
            vector2.DisplayElements();

            Console.WriteLine("Number of vectors: {0}", VectorDouble.GetNumVectors());

            // Add more operations and tests as needed
        }
    }



}
