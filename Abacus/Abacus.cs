using System;
using System.Collections.Generic;
using System.Text;

namespace Abacus
{
    

    class AbacusStruct
    {
        class AbacusBeed
        {
            bool value = false;

            public bool Value { get => value; set => this.value = value; }
        }

        AbacusBeed[][] beeds;

        private int dotPosition;
        private int value;
        private int beedLength;

        public int BeedLength { get => beedLength; }
        public int DotPosition { get => dotPosition; set => dotPosition = value; }

        public AbacusStruct(int length, int value, int dotPosition)
        {

            this.DotPosition = dotPosition;
            this.value = value;
            this.beedLength = length;

            beeds = new AbacusBeed[length][];

            for (int i = 0; i < beeds.Length; i++)
            {
                beeds[i] = new AbacusBeed[5];

                for (int j = 0; j < beeds[i].Length; j++)
                {
                    beeds[i][j] = new AbacusBeed();
                }
            }

            valueToBeeds();
        }

        public String getDisplayValue()
        {
            String displayValue;
            String displayRight, displayLeft;

            int rightLen, leftLen;

            displayValue = value.ToString().PadLeft(BeedLength, '0');

            rightLen = BeedLength - DotPosition;
            leftLen = BeedLength - rightLen;

            displayRight = displayValue.Substring(leftLen, rightLen);
            displayLeft = displayValue.Substring(0, leftLen);

            return displayLeft + "." + displayRight;
        }

        private void valueToBeeds()
        {
            int temp = this.value;
            int current;
            int lowBeedValue;
            int j, k;

            for (int i = 0; i < beeds.Length; i++)
            {
                current = temp % 10;
                beeds[i][0].Value = (current >= 5) ? true : false ;

                lowBeedValue = current % 5;

                for (j = 1; j <= lowBeedValue; j++)
                {
                    beeds[i][j].Value = true;
                }

                for (k = j; k < beeds[i].Length; k++)
                {
                    beeds[i][k].Value = false;
                }

                current /= 10;
            }
        }

        private int getColumnValue(AbacusBeed [] beedCol)
        {
            int val = 0;

            if (beedCol == null)
                throw new NullReferenceException();

            val += (beedCol[0].Value) ? 5 : 0;

            for (int i = 1; i < beedCol.Length; i++)
            {
                val += (beedCol[i].Value) ? 1 : 0;
            }

            return val;
        }

        private void beedsToValue()
        {
            int value = 0;

            for (int i = beeds.Length - 1; i >= 0; i--)
            {
                value *= 10;

                value += getColumnValue(beeds[i]);
            }

            this.value = value;
        }

        public void toggleBeed(int column, int row)
        {
            bool val;

            val = beeds[column][row].Value = !beeds[column][row].Value;

            if (row == 0) {
                beedsToValue();
                return;
            }

            if (val == true)
            {
                for (int i = row - 1; i >= 1; i--)
                {
                    beeds[column][i].Value = val;
                }
            }
            else
            {
                for (int i = row + 1; i < beeds[column].Length; i++)
                {
                    beeds[column][i].Value = val;
                }
            }
            
            beedsToValue();
        }

        public bool[] getBeedColumn(int col)
        {
            bool[] result = new bool[beeds[col].Length];

            for (int i = 0; i < beeds[col].Length; i++)
            {
                result[i] = beeds[col][i].Value;
            }

            return result;
        }
    }
}
