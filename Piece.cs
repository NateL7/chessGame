using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    class Piece
    {
        private int xLocation;
        private int yLocation;
        private string cColor;
        private string cName;

        private static bool cWhiteCanCastle = true;
        private static bool cBlackCanCastle = true;

        public Piece(int xLocation, int yLocation, string cColor, string cName)
        {
            this.xLocation = xLocation;
            this.yLocation = yLocation;
            this.cColor = cColor;
            this.cName = cName;

        }
        // class instances
        public int x
        {
            set { xLocation = value; }
            get { return xLocation; }
        }
        public int y
        {
            set { yLocation = value; }
            get { return yLocation; }
        }
        public string color
        {
            set { cColor = value; }
            get { return cColor; }
        }
        public string name
        {
            set { cName = value; }
            get { return cName; }
        }

        // static class instances
        public static bool whiteCanCastle
        {
            set { cWhiteCanCastle = value; }
            get { return cWhiteCanCastle; }
        }
        public static bool blackCanCastle
        {
            set { cBlackCanCastle = value; }
            get { return cBlackCanCastle; }
        }

        public static List<Point> whitePawnMoveOptions(List<Piece> pieceList, Piece pawn)
        {
            List<Point> posibleMoves = new List<Point>();
            bool canMoveUp1 = true;
            bool canMoveup2 = true;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pawn.x - 1 == pieceList[i].x && pawn.y - 1 == pieceList[i].y && pieceList[i].color == "black") // takeing a piece to the left
                {
                    posibleMoves.Add(new Point(pieceList[i].x, pieceList[i].y));
                }
                if (pawn.x + 1 == pieceList[i].x && pawn.y - 1 == pieceList[i].y && pieceList[i].color == "black") // takeing a piece to the right
                {
                    posibleMoves.Add(new Point(pieceList[i].x, pieceList[i].y));
                }
                if (pawn.x == pieceList[i].x && pawn.y - 1 == pieceList[i].y)  // checking if there is a piece one square in front
                {
                    canMoveUp1 = false;
                    canMoveup2 = false;
                }
                if (pawn.x == pieceList[i].x && pawn.y - 2 == pieceList[i].y)  // checking if there is a pice two squares in front
                {
                    canMoveup2 = false;
                }
            }
            if (pawn.y != 6)                                                   // checking if the pawn has moved already
            {
                canMoveup2 = false;
            }
            if (canMoveUp1 == true)
            {
                Point point = new Point(pawn.x, pawn.y - 1);
                posibleMoves.Add(point);
            }
            if (canMoveup2 == true)
            {
                Point point = new Point(pawn.x, pawn.y - 2);
                posibleMoves.Add(point);
            }         
            return posibleMoves;
        }

        public static List<Point> blackPawnMoveOptions(List<Piece> pieceList, Piece pawn)
        {
            List<Point> posibleMoves = new List<Point>();
            bool canMoveDown1 = true;
            bool canMoveDown2 = true;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pawn.x - 1 == pieceList[i].x && pawn.y + 1 == pieceList[i].y && pieceList[i].color == "white") // takeing a piece to the left
                {
                    posibleMoves.Add(new Point(pieceList[i].x, pieceList[i].y));
                }
                if (pawn.x + 1 == pieceList[i].x && pawn.y + 1 == pieceList[i].y && pieceList[i].color == "white") // takeing a piece to the right
                {
                    posibleMoves.Add(new Point(pieceList[i].x, pieceList[i].y));
                }
                if (pawn.x == pieceList[i].x && pawn.y + 1 == pieceList[i].y)  // checking if there is a piece one square in front
                {
                    canMoveDown1 = false;
                    canMoveDown2 = false;
                }
                if (pawn.x == pieceList[i].x && pawn.y + 2 == pieceList[i].y)  // checking if there is a pice two squares in front
                {
                    canMoveDown2 = false;
                }
            }
            if (pawn.y != 1)                                                   // checking if the pawn has moved already
            {
                canMoveDown2 = false;
            }
            if (canMoveDown1 == true)
            {
                Point point = new Point(pawn.x, pawn.y + 1);
                posibleMoves.Add(point);
            }
            if (canMoveDown2 == true)
            {
                Point point = new Point(pawn.x, pawn.y + 2);
                posibleMoves.Add(point);
            }
            return posibleMoves;
        }



        public static List<Point> rookMoveOptions(List<Piece> pieceList, Piece rook)
        {
            List<Point> posibleMoves = new List<Point>();
            bool canMoveUp = true;
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;
            int i = 1;
            while (canMoveUp == true)
            {
                if (rook.y - i < 0) canMoveUp = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (rook.x == pieceList[j].x && rook.y - i == pieceList[j].y)
                    {
                        canMoveUp = false;
                        if (rook.color != pieceList[j].color)
                        {
                           posibleMoves.Add(new Point(rook.x, rook.y - i));                        
                        }
                    }
                }
                if (canMoveUp == true) posibleMoves.Add(new Point(rook.x, rook.y - i));
                i++;                
            }

            i = 1;
            while (canMoveDown == true)
            {
                if (rook.y + i > 7) canMoveDown = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (rook.x == pieceList[j].x && rook.y + i == pieceList[j].y)
                    {
                        canMoveDown = false;
                        if (rook.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(rook.x, rook.y + i));
                        }
                    }
                }
                if (canMoveDown == true) posibleMoves.Add(new Point(rook.x, rook.y + i));
                i++;
            }

            i = 1;
            while (canMoveLeft == true)
            {
                if (rook.x - i < 0) canMoveLeft = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (rook.x - i == pieceList[j].x && rook.y == pieceList[j].y)
                    {
                        canMoveLeft = false;
                        if (rook.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(rook.x - i, rook.y));
                        }
                    }
                }
                if (canMoveLeft == true) posibleMoves.Add(new Point(rook.x - i, rook.y));
                i++;
            }

            i = 1;
            while (canMoveRight == true)
            {
                if (rook.x + i > 7) canMoveRight = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (rook.x + i == pieceList[j].x && rook.y == pieceList[j].y)
                    {
                        canMoveRight = false;
                        if (rook.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(rook.x + i, rook.y));
                        }
                    }
                }
                if (canMoveRight == true) posibleMoves.Add(new Point(rook.x + i, rook.y));
                i++;
            }


            return posibleMoves;
        }

        public static List<Point> bishopMoveOptions(List<Piece> pieceList, Piece bishop)
        {
            List<Point> posibleMoves = new List<Point>();
            bool canMoveUpLeft = true;
            bool canMoveUpRight = true;
            bool canMoveDownRight = true;
            bool canMoveDownLeft = true;
            int i = 1;
            while (canMoveUpLeft == true)
            {
                if (bishop.y - i < 0 || bishop.x - i < 0) canMoveUpLeft = false;   
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (bishop.x - i == pieceList[j].x && bishop.y - i == pieceList[j].y)
                    {
                        canMoveUpLeft = false;
                        if (bishop.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(bishop.x - i, bishop.y - i));
                        }
                    }
                }
                if (canMoveUpLeft == true) posibleMoves.Add(new Point(bishop.x - i, bishop.y - i));
                i++;
            }
            i = 1;
            while (canMoveUpRight == true)
            {
                if (bishop.y - i < 0 || bishop.x + i > 7) canMoveUpRight = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (bishop.x + i == pieceList[j].x && bishop.y - i == pieceList[j].y)
                    {
                        canMoveUpRight = false;
                        if (bishop.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(bishop.x + i, bishop.y - i));
                        }
                    }
                }
                if (canMoveUpRight == true) posibleMoves.Add(new Point(bishop.x + i, bishop.y - i));
                i++;
            }
            i = 1;
            while (canMoveDownRight == true)
            {
                if (bishop.y + i > 7 || bishop.x + i > 7) canMoveDownRight = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (bishop.x + i == pieceList[j].x && bishop.y + i == pieceList[j].y)
                    {
                        canMoveDownRight = false;
                        if (bishop.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(bishop.x + i, bishop.y + i));
                        }
                    }
                }
                if (canMoveDownRight == true) posibleMoves.Add(new Point(bishop.x + i, bishop.y + i));
                i++;
            }
            i = 1;
            while (canMoveDownLeft == true)
            {
                if (bishop.y + i > 7 || bishop.x - i < 0) canMoveDownLeft = false;
                for (int j = 0; j < pieceList.Count(); j++)
                {
                    if (bishop.x - i == pieceList[j].x && bishop.y + i == pieceList[j].y)
                    {
                        canMoveDownLeft = false;
                        if (bishop.color != pieceList[j].color)
                        {
                            posibleMoves.Add(new Point(bishop.x - i, bishop.y + i));
                        }
                    }
                }
                if (canMoveDownLeft == true) posibleMoves.Add(new Point(bishop.x - i, bishop.y + i));
                i++;
            }
            return posibleMoves;
        }

        public static List<Point> knightMoveOptions(List<Piece> pieceList, Piece knight)
        {
            List<Point> posibleMoves = new List<Point>();
            bool upUpLeft = true;
            bool upUpRight = true;
            bool rightRightUp = true;
            bool rightRightDown = true;
            bool downDownRight = true;
            bool downDownLeft = true;
            bool leftLeftUp = true;
            bool leftLeftDown = true;

            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x - 1 == pieceList[i].x && knight.y -2 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    upUpLeft = false;
                } 
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x + 1 == pieceList[i].x && knight.y - 2 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    upUpRight = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x + 2 == pieceList[i].x && knight.y - 1 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    rightRightUp = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x + 2 == pieceList[i].x && knight.y + 1 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    rightRightDown = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x + 1 == pieceList[i].x && knight.y + 2 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    downDownRight = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x - 1 == pieceList[i].x && knight.y + 2 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    downDownLeft = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x - 2 == pieceList[i].x && knight.y - 1 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    leftLeftUp = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (knight.x - 2 == pieceList[i].x && knight.y + 1 == pieceList[i].y && knight.color == pieceList[i].color)
                {
                    leftLeftDown = false;
                }
            }
            if (upUpLeft == true) posibleMoves.Add(new Point(knight.x - 1, knight.y - 2));
            if (upUpRight == true) posibleMoves.Add(new Point(knight.x + 1, knight.y - 2));
            if (rightRightUp == true) posibleMoves.Add(new Point(knight.x + 2, knight.y - 1));
            if (rightRightDown == true) posibleMoves.Add(new Point(knight.x + 2, knight.y + 1));
            if (downDownRight == true) posibleMoves.Add(new Point(knight.x + 1, knight.y + 2));
            if (downDownLeft == true) posibleMoves.Add(new Point(knight.x - 1, knight.y + 2));
            if (leftLeftUp == true) posibleMoves.Add(new Point(knight.x - 2, knight.y - 1));
            if (leftLeftDown == true) posibleMoves.Add(new Point(knight.x - 2, knight.y + 1));
            return posibleMoves;
        }



        public static List<Point> kingMovesOptions(List<Piece> pieceList, Piece king, Piece rook1, Piece rook2)
        {
            List<Point> posibleMoves = new List<Point>();
            bool moveUp = true;
            bool moveUpLeft = true;
            bool moveUpRight = true;
            bool moveLeft = true;
            bool moveRight = true;
            bool moveDown = true;
            bool moveDownLeft = true;
            bool moveDownRight = true;
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x == pieceList[i].x && king.y -1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveUp = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x - 1 == pieceList[i].x && king.y - 1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveUpLeft = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x + 1 == pieceList[i].x && king.y - 1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveUpRight = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x - 1 == pieceList[i].x && king.y == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveLeft = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x + 1 == pieceList[i].x && king.y == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveRight = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x == pieceList[i].x && king.y + 1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveDown = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x - 1 == pieceList[i].x && king.y + 1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveDownLeft = false;
                }
            }
            for (int i = 0; i < pieceList.Count(); i++)
            {
                if (king.x + 1 == pieceList[i].x && king.y + 1 == pieceList[i].y && king.color == pieceList[i].color)
                {
                    moveDownRight = false;
                }
            }
            if (moveUp == true) posibleMoves.Add(new Point(king.x, king.y - 1));
            if (moveUpLeft == true) posibleMoves.Add(new Point(king.x - 1, king.y - 1));
            if (moveUpRight == true) posibleMoves.Add(new Point(king.x + 1, king.y - 1));
            if (moveLeft == true) posibleMoves.Add(new Point(king.x - 1, king.y));
            if (moveRight == true) posibleMoves.Add(new Point(king.x + 1, king.y));
            if (moveDown == true) posibleMoves.Add(new Point(king.x, king.y + 1));
            if (moveDownLeft == true) posibleMoves.Add(new Point(king.x - 1, king.y + 1));
            if (moveDownRight == true) posibleMoves.Add(new Point(king.x + 1, king.y + 1));

            List<string> castleOptions = new List<string>();                                  // this and the next 6 lines of code or for castling
            if (king.color == "white")  castleOptions = checkIfCanCastleWhite(pieceList, rook1, rook2);
            for (int i = 0; i < castleOptions.Count(); i++)
            {
                if (castleOptions[i] == "left") posibleMoves.Add(new Point(1, 7));
                if (castleOptions[i] == "right") posibleMoves.Add(new Point(6, 7));
            }
            if (king.color == "black") castleOptions = checkIfCanCastleBlack(pieceList, rook1, rook2);
            for (int i = 0; i < castleOptions.Count(); i++)
            {
                if (castleOptions[i] == "left") posibleMoves.Add(new Point(1, 0));
                if (castleOptions[i] == "right") posibleMoves.Add(new Point(6, 0));
            }
            return posibleMoves;
        }



        public static List<Point> queenMoveOptions(List<Piece> pieceList, Piece queen)
        {
            List<Point> moveOptions = new List<Point>();
            List<Point> moreMoveOptions = new List<Point>();

            moveOptions = rookMoveOptions(pieceList, queen);
            moreMoveOptions = bishopMoveOptions(pieceList, queen);

            for (int i = 0; i < moreMoveOptions.Count; i++)
            {
                moveOptions.Add(new Point(moreMoveOptions[i].X, moreMoveOptions[i].Y));
            }

            return moveOptions;
        }


        public static List<string> checkIfCanCastleWhite(List<Piece> pieceList, Piece rook1, Piece rook2)
        {
           // Form1 f = new Form1();                                      // not sure how to get around making an object of form 1 for acessing its data  remove if no problems
            bool castleLeft = false;
            bool castleRight = false;
            List<Point> rooksLocation = new List<Point>();
            List<string> results = new List<string>();
            if (whiteCanCastle == false)                               // checks to see if the king has moved already.
            {
                results.Add("no");
                return results;
            }
            else
            {
                rooksLocation.Add(new Point(rook1.x, rook1.y));          // adds the rooks locations to rooksLocations list
                rooksLocation.Add(new Point(rook2.x, rook2.y));
                for (int i = 0; i < 2; i++)
                {
                    if (rooksLocation[i].X == 0 && rooksLocation[i].Y == 7)
                    {
                        castleLeft = true;
                    }
                    if (rooksLocation[i].X == 7 && rooksLocation[i].Y == 7)
                    {
                        castleRight = true;
                    }
                }
            }
            if (castleLeft == true)
            {
                for (int i = 0; i < pieceList.Count(); i++)
                {
                    if (pieceList[i].x == 1 && pieceList[i].y == 7 || pieceList[i].x == 2 && pieceList[i].y == 7 || pieceList[i].x == 3 && pieceList[i].y == 7)
                    {
                        castleLeft = false;
                    }                  
                }
            }
            if (castleRight == true)
            {
                for (int i = 0; i < pieceList.Count(); i++)
                {            
                    if (pieceList[i].x == 5 && pieceList[i].y == 7 || pieceList[i].x == 6 && pieceList[i].y == 7)
                    {
                        castleRight = false;
                    }
                }
            }
            if (castleLeft == true) results.Add("left");
            if (castleRight == true) results.Add("right");
            return results;
            
        }


        public static List<string> checkIfCanCastleBlack(List<Piece> pieceList, Piece rook1, Piece rook2)
        {            
            bool castleLeft = false;
            bool castleRight = false;
            List<Point> rooksLocation = new List<Point>();
            List<string> results = new List<string>();
            if (blackCanCastle == false)                               // checks to see if the king has moved already.
            {
                results.Add("no");
                return results;
            }
            else
            {
                rooksLocation.Add(new Point(rook1.x, rook1.y));          // adds the rooks locations to rooksLocations list
                rooksLocation.Add(new Point(rook2.x, rook2.y));
                for (int i = 0; i < 2; i++)
                {
                    if (rooksLocation[i].X == 0 && rooksLocation[i].Y == 0)
                    {
                        castleLeft = true;
                    }
                    if (rooksLocation[i].X == 7 && rooksLocation[i].Y == 0)
                    {
                        castleRight = true;
                    }
                }
            }
            if (castleLeft == true)
            {
                for (int i = 0; i < pieceList.Count(); i++)
                {
                    if (pieceList[i].x == 1 && pieceList[i].y == 0 || pieceList[i].x == 2 && pieceList[i].y == 0 || pieceList[i].x == 3 && pieceList[i].y == 0)
                    {
                        castleLeft = false;
                    }
                }
            }
            if (castleRight == true)
            {
                for (int i = 0; i < pieceList.Count(); i++)
                {
                    if (pieceList[i].x == 5 && pieceList[i].y == 0 || pieceList[i].x == 6 && pieceList[i].y == 0)
                    {
                        castleRight = false;
                    }
                }
            }
            if (castleLeft == true) results.Add("left");
            if (castleRight == true) results.Add("right");
            return results;

        }
    


    }
}     

