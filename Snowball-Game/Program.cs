using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnowballGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //team scores
            int blueScore = 0;
            int redScore = 0;

            //blue team snowman and thrower
            int Ax = 0;//first snowman
            int Ay = 0;
            Boolean isAalive = true;
            int AxSize = 1;
            int AySize = 1;
            int Bx = 0; //second snowman
            int By = 0;
            Boolean isBalive = true;
            int BxSize = 1;
            int BySize = 1;
            int blueThrowerX = 0;
            int blueThrowerY = 0;

            //red team
            int Cx = 0; //first snowman
            int Cy = 0;
            Boolean isCalive = true;
            int CxSize = 1;
            int CySize = 1;
            int Dx = 0; //second snowman
            int Dy = 0;
            Boolean isDalive = true;
            int DxSize = 1;
            int DySize = 1;
            int redThrowerX = 0;
            int redThrowerY = 0;

            //wall coordinates and lenghts
            int wall1X = 0;
            int wall1Y = 0;
            int wall1Length = 0;
            int wall2X = 0;
            int wall2Y = 0;
            int wall2Length = 0;

            //other variables
            int round = 0;
            int totalRound = 0;
            double wind;
            int gravity = -1;
            double velocity;
            double angle;
            int turnInteger = 0; //0 blue, 1 red
            String turn;

            if (turnInteger == 0)
            {
                turn = "Blue";
            }
            else
            {
                turn = "Red ";
            }

            Console.Write("PRESS ANY BUTTON TO START THE GAME");
            Console.ReadKey();
            Console.Clear();

            //info box
            Console.SetCursorPosition(2, 0);
            Console.Write("Round: " + totalRound);
            Console.SetCursorPosition(2, 1);
            Console.Write("Turn: " + turn);
            Console.SetCursorPosition(2, 2);
            Console.Write("Wind: ");
            Console.SetCursorPosition(2, 3);
            Console.Write("Velocity: ");
            Console.SetCursorPosition(2, 4);
            Console.Write("Angle: ");

            /* team members coordinates x(1-120), y(6,46)
             * blue x(1,41) 
             * neutral x(41,81) y(6,46)
             * red x(81,121)
            */

            Random random = new Random();

            //main game loop
            for (; blueScore != 2 || redScore != 2; round++, totalRound++)
            {
                //update whose turn
                if (turnInteger == 0)
                {
                    turn = "Blue";
                }
                else
                {
                    turn = "Red";
                }

                //clear and redraw the game field at the start of every third round
                if (round % 2 == 0)
                {
                    if (totalRound != 0)
                    {
                        Console.SetCursorPosition(60, 2);
                        Console.Write("PRESS ANY BUTTON TO CONTINUE");
                        Console.ReadKey();
                    }

                    Console.Clear();

                    //GAME SCREEN
                    int areaX = 120;
                    int areaY = 40;


                    Console.SetWindowSize(areaX + 8, areaY + 8);
                    Console.SetBufferSize(areaX + 8, areaY + 8);




                    Console.SetCursorPosition(1, 5);

                    for (int i = 0; i < areaX; i++) //top border
                    {
                        Console.Write("-");
                    }

                    Console.SetCursorPosition(0, 0);

                    for (int i = 0; i < areaY + 6; i++) //left border
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("|");
                    }

                    Console.SetCursorPosition(1, areaY + 5);

                    for (int i = 0; i < areaX; i++) //bottom border
                    {
                        Console.SetCursorPosition(i + 1, areaY + 6);
                        Console.Write("-");
                    }

                    Console.SetCursorPosition(areaX + 1, 2);

                    for (int i = 0; i < areaY + 6; i++) //right border
                    {
                        Console.SetCursorPosition(areaX + 1, i);
                        Console.Write("|");
                    }

                    Console.SetCursorPosition(0, 5);
                    Console.Write("#");
                    Console.SetCursorPosition(121, 5);
                    Console.Write("#");
                    Console.SetCursorPosition(0, 46);
                    Console.Write("#");
                    Console.SetCursorPosition(121, 46);
                    Console.Write("#");

                    //blue team locations
                    Ax = random.Next(1, 40);
                    Ay = random.Next(6, 46);

                    Bx = random.Next(1, 40);
                    By = random.Next(6, 46);

                    while (Ay == By && Ax == Bx)
                    {
                        By = random.Next(6, 46);
                    }

                    //randomize thrower position (avoid overlap)
                    blueThrowerX = random.Next(1, 40);
                    blueThrowerY = random.Next(6, 46);
                    while ((blueThrowerY == By && blueThrowerX == Bx) || (blueThrowerY == Ay && blueThrowerX == Ax))
                    {
                        blueThrowerY = random.Next(6, 46);

                    }

                    if (isAalive)
                    {
                        for (int y = 0; y < AySize; y++)
                        {
                            for (int x = 0; x < AxSize; x++)
                            {
                                if ((Ay - y) > 5)
                                {
                                    Console.SetCursorPosition(Ax + x, Ay - y);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("A");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }

                    if (isBalive)
                    {
                        for (int y = 0; y < BySize; y++)
                        {
                            for (int x = 0; x < BxSize; x++)
                            {
                                if ((By - y) > 5)
                                {
                                    Console.SetCursorPosition(Bx + x, By - y);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("B");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }

                    Console.SetCursorPosition(blueThrowerX, blueThrowerY);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(">");
                    Console.ResetColor();

                    //red team locations
                    Cx = random.Next(81, 120);
                    Cy = random.Next(6, 46);

                    Dx = random.Next(81, 120);
                    Dy = random.Next(6, 46);
                    while (Cx == Dx && Cy == Dy)
                    {
                        Dy = random.Next(6, 46);
                    }

                    //randomize thrower position (avoid overlap)
                    redThrowerX = random.Next(81, 120);
                    redThrowerY = random.Next(6, 46);
                    while ((redThrowerY == Dy && redThrowerX == Dx) || (redThrowerY == Cy && redThrowerX == Cx))
                    {
                        redThrowerY = random.Next(6, 46);

                    }

                    if (isCalive)
                    {
                        for (int y = 0; y < CySize; y++)
                        {
                            for (int x = 0; x < CxSize; x++)
                            {
                                if ((Cy - y) > 5)
                                {
                                    Console.SetCursorPosition(Cx + x, Cy - y);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("C");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    if (isDalive)
                    {
                        for (int y = 0; y < DySize; y++)
                        {
                            for (int x = 0; x < DxSize; x++)
                            {
                                if ((Dy - y) > 5)
                                {
                                    Console.SetCursorPosition(Dx + x, Dy - y);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("D");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }

                    Console.SetCursorPosition(redThrowerX, redThrowerY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("<");
                    Console.ResetColor();

                    /*
                     * neutral x(41, 81) y(6, 46)
                     */

                    //wall locations
                    wall1X = random.Next(41, 81);
                    wall1Y = random.Next(12, 46);
                    wall1Length = random.Next(3, 7);

                    wall2X = random.Next(41, 81);
                    wall2Y = random.Next(12, 46);
                    wall2Length = random.Next(3, 7);
                    while (wall1X == wall2X && wall1Y == wall2Y)
                    {
                        wall2Y = random.Next(6, 46);
                    }

                    //draw wall shapes
                    for (int i = 0; i < wall1Length; i++)
                    {
                        if ((wall1Y - i) > 5)
                        {
                            Console.SetCursorPosition(wall1X, wall1Y - i);
                            Console.Write("#");
                        }
                    }

                    for (int i = 0; i < wall2Length; i++)
                    {
                        if ((wall2Y - i) > 5)
                        {
                            Console.SetCursorPosition(wall2X, wall2Y - i);
                            Console.Write("#");
                        }
                    }
                }

                //update info box
                Console.SetCursorPosition(2, 0);
                Console.Write("Round: " + totalRound);
                Console.SetCursorPosition(2, 1);
                Console.Write("Turn: " + turn);
                wind = Math.Round((random.NextDouble() * 4) - 2, 2); // random wind each turn (-2 to +2)
                Console.SetCursorPosition(2, 2);
                Console.Write("Wind: " + wind);

                Console.SetCursorPosition(2, 3);
                Console.Write("Velocity:      ");
                Console.SetCursorPosition(2, 4);
                Console.Write("Angle:      ");

                //input for velocity and angle
                Console.SetCursorPosition(60, 2);
                Console.Write(turn.ToUpper() + " TEAM, ENTER VELOCITY (5.0 - 25): ");
                velocity = Convert.ToDouble(Console.ReadLine());

                while (!(velocity >= 5.0 && velocity <= 25.00))
                {
                    Console.SetCursorPosition(60, 2);
                    Console.Write("                                            ");
                    Console.SetCursorPosition(60, 2);
                    Console.Write("Please enter a valid velocity: ");
                    velocity = Convert.ToDouble(Console.ReadLine());
                }

                Console.SetCursorPosition(2, 3);
                Console.Write("Velocity: " + velocity);
                Console.SetCursorPosition(60, 2);
                Console.Write("                                            ");


                Console.SetCursorPosition(60, 2);
                Console.Write(turn.ToUpper() + " TEAM, ENTER ANGLE (-85.0 - 85.0): ");
                angle = Convert.ToDouble(Console.ReadLine());
                while (!(angle >= -85.0 && angle <= 85.00))
                {
                    Console.SetCursorPosition(60, 2);
                    Console.Write("                                            ");
                    Console.SetCursorPosition(60, 2);
                    Console.Write("Please enter a valid angle: ");
                    angle = Convert.ToDouble(Console.ReadLine());
                }

                Console.SetCursorPosition(2, 4);
                Console.Write("Angle: " + angle);
                Console.SetCursorPosition(60, 2);
                Console.Write("                                            ");

                //calculate projectile motion
                double velocityX = velocity * Math.Cos(angle * Math.PI / 180.0); //radyan
                double velocityY = velocity * Math.Sin(angle * Math.PI / 180.0);

                if (turnInteger == 1) //reverse direction for red team
                {
                    velocityX = -velocityX;

                }

                velocityX = velocityX + wind; //apply wind to velocity

                double time = 0;
                int positionX = 0;
                int positionY = 0;
                int hit = 0; //0: no , 1: yes
                int hitWall = 0;

                if (turnInteger == 0) //BLUE TURN
                {

                    double controlTime = 0;
                    int controlPositionX = blueThrowerX;
                    int controlPositionY = blueThrowerY;
                    int totalSteps = 0;
                    bool controlHit = false;
                    while (true)
                    {
                        controlPositionX = (int)(blueThrowerX + velocityX * controlTime);
                        controlPositionY = (int)(blueThrowerY - (velocityY * controlTime + 0.5 * gravity * controlTime * controlTime));

                        if (controlPositionX < 0 || controlPositionX > 122 || controlPositionY > 47) break;

                        if (controlHit) break;

                        if (isCalive)
                        {
                            for (int y = 0; y < CySize; y++)
                            {
                                for (int x = 0; x < CxSize; x++)
                                {
                                    if (controlPositionX == (Cx + x) && controlPositionY == (Cy - y)) controlHit = true;
                                }
                            }
                        }
                        if (isDalive)
                        {
                            for (int y = 0; y < DySize; y++)
                            {
                                for (int x = 0; x < DxSize; x++)
                                {
                                    if (controlPositionX == (Dx + x) && controlPositionY == (Dy - y)) controlHit = true;
                                }
                            }
                        }
                        if (isAalive)
                        {
                            for (int y = 0; y < AySize; y++)
                            {
                                for (int x = 0; x < AxSize; x++)
                                {
                                    if (controlPositionX == (Ax + x) && controlPositionY == (Ay - y)) controlHit = true;
                                }
                            }
                        }
                        if (isBalive)
                        {
                            for (int y = 0; y < BySize; y++)
                            {
                                for (int x = 0; x < BxSize; x++)
                                {
                                    if (controlPositionX == (Bx + x) && controlPositionY == (By - y)) controlHit = true;
                                }
                            }
                        }
                        if (controlPositionX == redThrowerX && controlPositionY == redThrowerY) controlHit = true;

                        for (int i = 0; i < wall1Length; i++)
                        {
                            if ((controlPositionX == wall1X) && (controlPositionY == wall1Y - i)) controlHit = true;
                        }
                        for (int i = 0; i < wall2Length; i++)
                        {
                            if ((controlPositionX == wall2X) && (controlPositionY == wall2Y - i)) controlHit = true;
                        }


                        if (controlPositionY > 5)
                        {
                            totalSteps++;
                        }
                        controlTime += 0.1;
                    }

                    int stepsPerColor = Math.Max(1, totalSteps / 3);
                    int currentStep = 0;

                    Console.SetCursorPosition(60, 4);
                    Console.Write("                                                                                ");
                    while (true)
                    {
                        if (hitWall == 1)
                        {
                            break;
                        }

                        //projectile position update for drawing its trace
                        positionX = (int)(blueThrowerX + velocityX * time);
                        positionY = (int)(blueThrowerY - (velocityY * time + 0.5 * gravity * time * time));

                        //stop if out of bounds
                        if (positionX < 0 || positionX > 122 || positionY > 47)
                        {
                            break;
                        }

                        time += 0.1;

                        if (positionY > 5)
                        {

                            if (positionX != blueThrowerX && positionY != blueThrowerY)
                            {
                                Console.SetCursorPosition(positionX, positionY);

                                currentStep++;
                                if (angle >= 0)
                                {
                                    if (currentStep <= stepsPerColor) Console.ForegroundColor = ConsoleColor.Red;
                                    else if (currentStep <= stepsPerColor * 2) Console.ForegroundColor = ConsoleColor.Blue;
                                    else Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    if (currentStep <= stepsPerColor) Console.ForegroundColor = ConsoleColor.Green;
                                    else if (currentStep <= stepsPerColor * 2) Console.ForegroundColor = ConsoleColor.Blue;
                                    else Console.ForegroundColor = ConsoleColor.Red;
                                }
                                Console.Write("o");
                                Console.ResetColor();
                            }
                        }

                        //check collision with snowmen, thrower or wall
                        if (isAalive)
                        {
                            for (int y = 0; y < AySize; y++)
                            {
                                for (int x = 0; x < AxSize; x++)
                                {
                                    if (positionX == (Ax + x) && positionY == (Ay - y))
                                    {
                                        isAalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Blue team hit its own snowman.");
                                        turnInteger = 1;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isBalive)
                        {
                            for (int y = 0; y < BySize; y++)
                            {
                                for (int x = 0; x < BxSize; x++)
                                {
                                    if (positionX == (Bx + x) && positionY == (By - y))
                                    {
                                        isBalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Blue team eliminated its own snowman.");
                                        turnInteger = 1;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isCalive)
                        {
                            for (int y = 0; y < CySize; y++)
                            {
                                for (int x = 0; x < CxSize; x++)
                                {
                                    if (positionX == (Cx + x) && positionY == (Cy - y))
                                    {
                                        isCalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Blue team eliminated a Red team snowman.");
                                        turnInteger = 1;
                                        blueScore++;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isDalive)
                        {
                            for (int y = 0; y < DySize; y++)
                            {
                                for (int x = 0; x < DxSize; x++)
                                {
                                    if (positionX == (Dx + x) && positionY == (Dy - y))
                                    {
                                        isDalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Blue team eliminated a Red team snowman.");
                                        turnInteger = 1;
                                        blueScore++;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (positionX == redThrowerX && positionY == redThrowerY)
                        {
                            Console.SetCursorPosition(60, 4);
                            Console.Write("Blue team hit the Red team's thrower, it's Blue's turn again.");
                            hit = 1;
                            break;
                        }

                        for (int i = 0; i < wall1Length; i++) // check if the first wall is hit
                        {
                            if ((positionX == wall1X) && (positionY == wall1Y - i))
                            {
                                Console.SetCursorPosition(60, 4);
                                Console.Write("Blue team hit a wall.");
                                turnInteger = 1;
                                hitWall = 1;
                                break;
                            }

                        }
                        if (hitWall == 1) break;

                        for (int i = 0; i < wall2Length; i++) // check if the second wall is hit
                        {
                            if ((positionX == wall2X) && (positionY == wall2Y - i))
                            {
                                Console.SetCursorPosition(60, 4);
                                Console.Write("Blue team hit a wall.");
                                turnInteger = 1;
                                hitWall = 1;
                                break;
                            }
                        }
                        if (hitWall == 1) break;

                    }

                    if (hit == 0 && hitWall == 0)
                    {
                        Console.SetCursorPosition(60, 4);
                        Console.Write("Blue team couldn't hit anything.");
                        turnInteger = 1;

                        int snowmanChoice = random.Next(0, 2);
                        int axisChoice = random.Next(0, 2);

                        if (snowmanChoice == 0 && isCalive)
                        {
                            if (axisChoice == 1 && (Cy - CySize) > 6) CySize++;
                            else if (axisChoice == 0 && (Cx + CxSize) < 120) CxSize++;
                        }
                        else if (snowmanChoice == 1 && isDalive)
                        {
                            if (axisChoice == 1 && (Dy - DySize) > 6) DySize++;
                            else if (axisChoice == 0 && (Dx + DxSize) < 120) DxSize++;
                        }

                    }

                }

                else if (turnInteger == 1) // RED TURN
                {

                    double controlTime = 0;
                    int controlPositionX = redThrowerX;
                    int controlPositionY = redThrowerY;
                    int totalSteps = 0;
                    bool controlHit = false;
                    while (true)
                    {
                        controlPositionX = (int)(redThrowerX + velocityX * controlTime);
                        controlPositionY = (int)(redThrowerY - (velocityY * controlTime + 0.5 * gravity * controlTime * controlTime));

                        if (controlPositionX < 0 || controlPositionX > 122 || controlPositionY > 47) break;

                        if (controlHit) break;

                        if (isCalive)
                        {
                            for (int y = 0; y < CySize; y++)
                            {
                                for (int x = 0; x < CxSize; x++)
                                {
                                    if (controlPositionX == (Cx + x) && controlPositionY == (Cy - y)) controlHit = true;
                                }
                            }
                        }
                        if (isDalive)
                        {
                            for (int y = 0; y < DySize; y++)
                            {
                                for (int x = 0; x < DxSize; x++)
                                {
                                    if (controlPositionX == (Dx + x) && controlPositionY == (Dy - y)) controlHit = true;
                                }
                            }
                        }
                        if (isAalive)
                        {
                            for (int y = 0; y < AySize; y++)
                            {
                                for (int x = 0; x < AxSize; x++)
                                {
                                    if (controlPositionX == (Ax + x) && controlPositionY == (Ay - y)) controlHit = true;
                                }
                            }
                        }
                        if (isBalive)
                        {
                            for (int y = 0; y < BySize; y++)
                            {
                                for (int x = 0; x < BxSize; x++)
                                {
                                    if (controlPositionX == (Bx + x) && controlPositionY == (By - y)) controlHit = true;
                                }
                            }
                        }
                        if (controlPositionX == blueThrowerX && controlPositionY == blueThrowerY) controlHit = true;

                        for (int i = 0; i < wall1Length; i++)
                        {
                            if ((controlPositionX == wall1X) && (controlPositionY == wall1Y - i)) controlHit = true;
                        }
                        for (int i = 0; i < wall2Length; i++)
                        {
                            if ((controlPositionX == wall2X) && (controlPositionY == wall2Y - i)) controlHit = true;
                        }


                        if (controlPositionY > 5)
                        {
                            totalSteps++;
                        }
                        controlTime += 0.1;
                    }

                    int stepsPerColor = Math.Max(1, totalSteps / 3);
                    int currentStep = 0;

                    Console.SetCursorPosition(60, 4);
                    Console.Write("                                                                                ");
                    while (true)
                    {
                        if (hitWall == 1)
                        {
                            break;
                        }

                        positionX = (int)(redThrowerX + velocityX * time);
                        positionY = (int)(redThrowerY - (velocityY * time + 0.5 * gravity * time * time));

                        if (positionX < 0 || positionX > 122 || positionY > 47)
                        {
                            break;
                        }

                        time += 0.1;
                        if (positionY > 5)
                        {

                            if (positionX != redThrowerX && positionY != redThrowerY)
                            {
                                Console.SetCursorPosition(positionX, positionY);

                                currentStep++;
                                if (angle >= 0)
                                {
                                    if (currentStep <= stepsPerColor) Console.ForegroundColor = ConsoleColor.Red;
                                    else if (currentStep <= stepsPerColor * 2) Console.ForegroundColor = ConsoleColor.Blue;
                                    else Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    if (currentStep <= stepsPerColor) Console.ForegroundColor = ConsoleColor.Green;
                                    else if (currentStep <= stepsPerColor * 2) Console.ForegroundColor = ConsoleColor.Blue;
                                    else Console.ForegroundColor = ConsoleColor.Red;
                                }
                                Console.Write("o");
                                Console.ResetColor();
                            }
                        }

                        if (isAalive)
                        {
                            for (int y = 0; y < AySize; y++)
                            {
                                for (int x = 0; x < AxSize; x++)
                                {
                                    if (positionX == (Ax + x) && positionY == (Ay - y))
                                    {
                                        isAalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Red team eliminated a snowman.");
                                        turnInteger = 0;
                                        redScore++;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isBalive)
                        {
                            for (int y = 0; y < BySize; y++)
                            {
                                for (int x = 0; x < BxSize; x++)
                                {
                                    if (positionX == (Bx + x) && positionY == (By - y))
                                    {
                                        isBalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Red team eliminated a snowman.");
                                        turnInteger = 0;
                                        redScore++;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isCalive)
                        {
                            for (int y = 0; y < CySize; y++)
                            {
                                for (int x = 0; x < CxSize; x++)
                                {
                                    if (positionX == (Cx + x) && positionY == (Cy - y))
                                    {
                                        isCalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Red team eliminated its own snowman.");
                                        turnInteger = 0;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (isDalive)
                        {
                            for (int y = 0; y < DySize; y++)
                            {
                                for (int x = 0; x < DxSize; x++)
                                {
                                    if (positionX == (Dx + x) && positionY == (Dy - y))
                                    {
                                        isDalive = false;
                                        Console.SetCursorPosition(60, 4);
                                        Console.Write("Red team eliminated its own snowman.");
                                        turnInteger = 0;
                                        hit = 1;
                                        break;
                                    }
                                }
                                if (hit == 1) break;
                            }
                        }
                        if (hit == 1) break;

                        if (positionX == blueThrowerX && positionY == blueThrowerY)
                        {
                            Console.SetCursorPosition(60, 4);
                            Console.Write("Red team hit the Blue team's thrower, it's Red's turn again.");
                            hit = 1;
                            break;
                        }

                        for (int i = 0; i < wall1Length; i++) // 1. duvara vuruo
                        {
                            if ((positionX == wall1X) && (positionY == wall1Y - i))
                            {
                                Console.SetCursorPosition(60, 4);
                                Console.Write("Red team hit a wall.");
                                turnInteger = 0;
                                hitWall = 1;
                                break;
                            }

                        }
                        if (hitWall == 1) break;

                        for (int i = 0; i < wall2Length; i++) //2. duvara vuruooo
                        {
                            if ((positionX == wall2X) && (positionY == wall2Y - i))
                            {
                                Console.SetCursorPosition(60, 4);
                                Console.Write("Red team hit a wall.");
                                turnInteger = 0;
                                hitWall = 1;
                                break;
                            }
                        }
                        if (hitWall == 1) break;
                    }

                    if (hit == 0 && hitWall == 0)
                    {
                        Console.SetCursorPosition(60, 4);
                        Console.Write("Red team couldn't hit anything.");
                        turnInteger = 0;

                        int snowmanChoice = random.Next(0, 2);
                        int axisChoice = random.Next(0, 2);

                        if (snowmanChoice == 0 && isAalive)
                        {
                            if (axisChoice == 1 && (Ay - AySize) > 6) AySize++;
                            else if (axisChoice == 0 && (Ax + AxSize) < 40) AxSize++;
                        }
                        else if (snowmanChoice == 1 && isBalive)
                        {
                            if (axisChoice == 1 && (By - BySize) > 6) BySize++;
                            else if (axisChoice == 0 && (Bx + BxSize) < 40) BxSize++;
                        }

                    }

                }

                //win condition check
                if (blueScore == 2)
                {
                    Console.SetCursorPosition(60, 4);
                    Console.Write("BLUE TEAM HAS WON.");
                }
                else if (redScore == 2)
                {
                    Console.SetCursorPosition(60, 4);
                    Console.Write("RED TEAM HAS WON.");
                }
            } //end of game loop

            Console.ReadKey();
        }
    }
}
