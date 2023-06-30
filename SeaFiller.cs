using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyCraft
{
    // Класс - заполнитель поля.
    // Единственное его назначение - расставить 10 кораблей, чтобы они не соприкасались бортами
    public class SeaFiller
    {
        // Воспомогательный класс - корабль с координатами, длиной и направлением
        private class Ship
        {
            public int xs;
            public int ys;
            public bool ishorz;
            public int len;
        }

        // Карта кораблей, которую составляем
        private bool[,] ship;
                
        // Копировать карту кораблей в массив
        public void copyToArray(bool[,] dst)
        {
            for (int i = 0; i < Sea.SZ; i++)
                for (int j = 0; j < Sea.SZ; j++)
                    dst[i, j] = ship[i, j];
        }

        // Проверка, что клетки вокруг свободны
        private bool freeAround(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if ((x + i >= 0) && (y + j >= 0) && (x + i < Sea.SZ) && (y + j < Sea.SZ))
                        if (ship[x + i, y + j]) return false;
            return true;
        }

        // Получить список всех возможных вариантов установки корабля заданной длины
        private List<Ship> getValidShipsForLen(int Alen)
        {
            var res = new List<Ship>();

            for (int x = 0; x < Sea.SZ - Alen + 1; x++)
                for (int y = 0; y < Sea.SZ - Alen + 1; y++)
                {
                    // Проверка возможности горизонтальной установки
                    bool canhorz = true;
                    for (int q = 0; q < Alen; q++)
                        canhorz = canhorz && freeAround(x + q, y);
                    // Проверка возможности вертикальной установки
                    bool canvert = true;
                    for (int q = 0; q < Alen; q++)
                        canvert = canvert && freeAround(x, y + q);
                    if (canhorz) res.Add(new Ship() { xs = x, ys = y, len = Alen, ishorz = true });
                    if (canvert) res.Add(new Ship() { xs = x, ys = y, len = Alen, ishorz = false });
                }
            return res;
        }

        // Генератор случайных чисел и его создание
        private static Random rnd;
        private Random getRand()
        {
            if (rnd == null) rnd = new Random();
            return rnd;
        }

        // Получить случайный корабль заданной длины
        private Ship getRandomShip(int Alen)
        {
            var ships = getValidShipsForLen(Alen);
            if (ships.Count == 0) return null;
            return ships[getRand().Next(ships.Count)];
        }

        // Установить корабль в карту
        private void addShip(Ship Aship)
        {
            if (Aship.ishorz)
                for (int q = 0; q < Aship.len; q++)
                    ship[Aship.xs + q, Aship.ys] = true;
            else
                for (int q = 0; q < Aship.len; q++)
                    ship[Aship.xs, Aship.ys + q] = true;
        }

        // Конструктор установки кораблей
        public SeaFiller()
        {
            // Создать карту
            ship = new bool[Sea.SZ, Sea.SZ];

            bool isok = false;
            do
            {
                // Очистка поля
                for (int i = 0; i < Sea.SZ; i++)
                    for (int j = 0; j < Sea.SZ; j++)
                    {
                        ship[i, j] = false;
                    }
                isok = false;

                // Установить корабли случайно, всех типов и количества 1-2-3-4
                for (int len = 1; len <= 4; len++)
                    for (int cnt = 1; cnt <= 5 - len; cnt++)
                    {
                        Ship s = getRandomShip(len);
                        // Если какой-то корабль поставить не смогли, то выход из цикла
                        if (s == null) goto err;
                        addShip(s);
                    }
                // Если всё хорошо, то покидаем главный цикл
                isok = true;
                break;
                // Здесь означает, что будет повторять попытки, пока не пройдет без ошибок
            err: isok = false;

            }
            while (!isok);

        }

    }
}
