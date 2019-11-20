using System;
using System.Collections.Generic;

namespace Lab2
{
    public class SortedPosList
    {
        private List<Position> PositionList;
        public SortedPosList()
        {
            PositionList = new List<Position>();
        }

        public int Count()
        {
            return PositionList.Count;
        }

        public Position this[int key]
        {
            get => PositionList[key];
        }

        public void Add(Position pos)
        {
            int count = Count();

            if (count == 0)
            {
                PositionList.Add(pos);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (pos < PositionList[i] || pos == PositionList[i])
                    {
                        PositionList.Insert(i, pos);
                        break;
                    }
                    else if (i == count - 1)
                    {
                        PositionList.Add(pos);
                        break;
                    }
                }
            }

        }

        public bool Remove(Position pos)
        {
            int items = Count();
            for (int i = 0; i < items; i++)
            {
                if (pos.Equals(PositionList[i]))
                {
                    PositionList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }


        //Tittar ifall positionen är inuti cirkeln.
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList newPosList = new SortedPosList();

            foreach (Position pos in PositionList)
            {
                int x = pos.X - centerPos.X;
                int y = pos.Y - centerPos.Y;

                int powX = x * x;
                int powY = y * y;

                double posRadius = powX + powY;
                double centerRadius = radius * radius;

                if (posRadius < centerRadius)
                {
                    newPosList.Add(pos.Clone());
                }
            }
            return newPosList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList combinedPosList = new SortedPosList();

            for (int i = 0; i < sp1.Count(); i++)
            {
                combinedPosList.Add(sp1.PositionList[i]);
            }
            for (int i = 0; i < sp2.Count(); i++)
            {
                combinedPosList.Add(sp2.PositionList[i]);
            }
            return combinedPosList;
        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList newList = new SortedPosList();
            int sp1Value = 0;
            int sp2Value = 0;

            while (sp1Value < sp1.Count() && sp2Value < sp2.Count())
            {
                if (sp1[sp1Value] < sp2[sp2Value])
                {
                    newList.Add(sp1[sp1Value]);
                    sp1Value++;
                }
                else if (sp1[sp1Value] > sp2[sp2Value])
                {
                    sp2Value++;
                }
                else
                {
                    sp1Value++;
                    sp2Value++;
                }

            }
            return newList;
        }

        public override string ToString()
        {
            return string.Join(", ", PositionList);
        }
    }
}