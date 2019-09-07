using System;
using System.Collections;

namespace website
{
    internal class ArrayOfBits
    {
        private bool[] theArray;
        public int distance;

        public bool this[int key]
        {
            get
            {
                return theArray[key];
            }
            set
            {
                theArray[key] = value;
            }
        }

        public int getLength()
        {
            return theArray.Length;
        }

        public ArrayOfBits(int num, int size)
        {
            theArray = new bool[size];
            for (int i = 0; i < size; i++)
                theArray[i] = false;
            int k = 0;
            while (num != 0)
            {
                theArray[k] = (num % 2 == 1);
                num /= 2;
                k++;
            }
            computeDistance();
        }

        private void computeDistance()
        {
            int i;
            for (i = 0; i < theArray.Length; i++)
            {
                if (theArray[i] == true)
                    break;
            }
            int j;
            for (j = theArray.Length - 1; j >= 0; j--)
            {
                if (theArray[j] == true)
                    break;
            }
            distance = j - i + 1;
        }

        public ArrayOfBits And(ArrayOfBits b)
        {
            int resultNum = 0;
            int minimumSize = Math.Min(b.getLength(), theArray.Length);
            for (int i = 0; i < minimumSize; i++)
                if (b[i].Equals(theArray[i]))
                    resultNum += (b[i] ? 1 : 0) * (int)(Math.Pow(2, i));
            return new ArrayOfBits(resultNum, Math.Max(b.getLength(), theArray.Length));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(ArrayOfBits)))
            {
                int minimumSize = Math.Min(((ArrayOfBits)obj).getLength(), theArray.Length);
                for (int i = 0; i < minimumSize; i++)
                    if (!(((ArrayOfBits)obj)[i].Equals(theArray[i])))
                        return false;
                return true;
            }
            return base.Equals(obj);
        }

        public bool Match(ArrayOfBits b, int MCS)
        {
            int i = -1;
            for (i = 0; i < b.getLength(); i++)
            {
                if (b[i])
                    break;
            }
            int temp = i;
            for (int j = 0; j < b.distance; j++)
            {
                if (!b[j + temp].Equals(theArray[j + temp]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}