﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestingAppInterface
{
    static class InputProcessing
    {
        public static void CorrectInput(object sender)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            if (text.Length > 15)
            {
                textBox.Text = text.Substring(0, 15);
                textBox.SelectionStart = textBox.Text.Length;
            }

            // Если текст пуст, ничего не делаем
            if (string.IsNullOrEmpty(text))
                return;

            if(!long.TryParse(textBox.Text, out var value))
            {
                if (!IsAllowedSymbol(textBox.Text))
                {
                    // Удаляем последний символ
                    textBox.Text = text.Substring(0, text.Length - 1);
                    // Перемещаем курсор в конец текста
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }
        static bool IsAllowedSymbol(string symbol)
        {
            return symbol == ">" || symbol == "<" || symbol == "=";
        }
    }
}
