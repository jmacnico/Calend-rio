using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calendario
{
    public static class Calendario
    {
        public static Border GetCalendarioAnual(int ano)
        {
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            int row = 0;
            int Column = 0;
            for (int i = 1; i <= 12; i++)
            {
                StackPanel stk = new StackPanel() { Margin = new Thickness(3) };
                TextBlock txt = new TextBlock() { Text = GetMesOfNumber(i), HorizontalAlignment = HorizontalAlignment.Center };
                Border border = GetCalendarioMensal(i, ano);
                Grid.SetRow(stk, row);
                Grid.SetColumn(stk, Column);
                stk.Children.Add(txt);
                stk.Children.Add(border);
                grid.Children.Add(stk);
                if (i == 4 || i == 8 || i == 12)
                {
                    row++;
                    Column = 0;
                }
                else
                    Column++;
            }


            Border borderPrincipal = new Border() { BorderThickness = new System.Windows.Thickness(2, 2, 2, 2) };
            borderPrincipal.BorderBrush = Brushes.Black;
            borderPrincipal.Child = grid;
            return borderPrincipal;
        }

        public static Border GetCalendarioMensal(int mes, int ano)
        {
            
            Grid grid = new Grid();
            for (int i = 0; i < 7; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(column);
            }
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(GetBorderDay("Seg",0,0));
            grid.Children.Add(GetBorderDay("Ter", 1, 0));
            grid.Children.Add(GetBorderDay("Qua", 2, 0));
            grid.Children.Add(GetBorderDay("Qui", 3, 0));
            grid.Children.Add(GetBorderDay("Sex", 4, 0));
            grid.Children.Add(GetBorderDay("Sab", 5, 0));
            grid.Children.Add(GetBorderDay("Dom", 6, 0));
            grid.RowDefinitions.Add(new RowDefinition());
            DateTime date = new DateTime(ano, mes, 1);
            int position = (int)date.DayOfWeek;
            if (position == 0)
                position = 7;
            int row = 1;
            for (int i = 1; i <= DateTime.DaysInMonth(ano,mes); i++)
            {
                grid.Children.Add(GetBorderDay(i.ToString(), position - 1, row));
                if (position == 7 && i != DateTime.DaysInMonth(ano,mes))
                {
                    position = 1;
                    row++;
                    grid.RowDefinitions.Add(new RowDefinition());
                }                    
                else
                    position++;
            }

            Border border = new Border() { BorderThickness = new System.Windows.Thickness(2, 2, 2, 2) };
            border.BorderBrush = Brushes.Black;
            border.Child = grid;
            return border;
        }

        private static Border GetBorderDay(string day, int gridColumn, int gridRow)
        {
            Border border = new Border() { BorderThickness = new System.Windows.Thickness(1, 1, 1, 1)};
            border.BorderBrush = Brushes.Black;
            border.Margin = new Thickness(2);
            border.Child = new TextBlock() { Text = day, Margin = new Thickness(2) };
            Grid.SetColumn(border, gridColumn);
            Grid.SetRow(border, gridRow);
            return border;
        }

        private static string GetMesOfNumber(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
            }
            throw new Exception("Não existe o mês indicado");
        }
    }
}
