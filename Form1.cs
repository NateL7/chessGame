using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //++++++++++++++++++ Global Variables ++++++++++++++++++++++++++++++++++//
        List<Piece> piece = new List<Piece>();                      // A list of all 32 chess pieces
        Point selectedPiece = new Point(-1, -1);                    // This is the x and y cordinates of the piece that is selected.
        List<Point> posibleMoves = new List<Point>();               // Keeps track of legal posible moves
        bool whitesTurn = true;

        // ++++++++++++++++++GLobal Variables for Graphics +++++++++++++++++++++//
        Graphics g;
        SolidBrush blackBrush;
        SolidBrush whiteBrush;
        SolidBrush blueBrush;
        SolidBrush redBrush;
        SolidBrush greenBrush;
        Pen yellowPen;
        Pen blackPen;
        Pen whitePen;

        private void pnlGameBoard_Click(object sender, EventArgs e)
        {
            drawGame();
            Point mouseLocation = PointToClient(Cursor.Position);
            mouseLocation.X = mouseLocation.X - 100;
            mouseLocation.Y = mouseLocation.Y - 100;
            bool isMoveing = false;

            if (selectedPiece.X > -1)                       // This loop will move the piece.  When selected piece = -1 it means that there is no selected piece. 
            {                                               // The selectedPiece is the piece you are thinking about moving.  It and its move options are highlighted. 
                for (int i = 0; i < posibleMoves.Count(); i++)
                {
                    if (posibleMoves[i].X * 50 < mouseLocation.X && mouseLocation.X < (posibleMoves[i].X * 50) + 50 && posibleMoves[i].Y * 50 < mouseLocation.Y && mouseLocation.Y < (posibleMoves[i].Y * 50) + 50)
                    {
                        for (int j = 0; j < piece.Count(); j++)
                        {
                            if (piece[j].x == selectedPiece.X && piece[j].y == selectedPiece.Y)   // Everything that is inside this if block.  Will be exicuted when the player desides to
                            {                                                                     // move the selected piece.
                                killPiece(posibleMoves[i]);
                                if (piece[j].name == "king" && piece[j].color == "white") checkIfWhiteCastled(posibleMoves[i]);
                                if (piece[j].name == "king" && piece[j].color == "white") Piece.whiteCanCastle = false;
                                if (piece[j].name == "king" && piece[j].color == "black") checkIfBlackCastled(posibleMoves[i]);
                                if (piece[j].name == "king" && piece[j].color == "black") Piece.blackCanCastle = false;
                                piece[j].x = posibleMoves[i].X;
                                piece[j].y = posibleMoves[i].Y;
                                drawGame();
                                posibleMoves.Clear();
                                selectedPiece = new Point(-1, -1);
                                isMoveing = true;
                                if (whitesTurn == true) whitesTurn = false;
                                else whitesTurn = true;
                                break;
                            }
                        }
                    }
                }
            }
            // when isMoving = false.  It means that the player is selelcting a piece.
            if (isMoveing == false)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (piece[i].x * 50 < mouseLocation.X && mouseLocation.X < (piece[i].x * 50) + 50 && piece[i].y * 50 < mouseLocation.Y && mouseLocation.Y < (piece[i].y * 50) + 50)
                    {
                        if (piece[i].name == "pawn" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.whitePawnMoveOptions(piece, piece[i]);      // caculates all the legal moves
                            drawMoveOptions(posibleMoves);                                   // Highlights all the squares that are legal moves
                            selectedPiece = new Point(piece[i].x, piece[i].y);               // selected piece is the piece that you are about to move
                            borderselectedpiece(selectedPiece);                              // draws a bourder around the selected Piece
                        }
                        else if (piece[i].name == "pawn" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.blackPawnMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "rook" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.rookMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "rook" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.rookMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "bishop" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.bishopMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "bishop" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.bishopMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "knight" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.knightMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "knight" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.knightMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "king" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.kingMovesOptions(piece, piece[i], piece[28], piece[29]);     // piece 28 and 29 or the two white rooks - this information is for the castling
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "king" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.kingMovesOptions(piece, piece[i], piece[12], piece[13]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "queen" && piece[i].color == "white" && whitesTurn == true)
                        {
                            posibleMoves = Piece.queenMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else if (piece[i].name == "queen" && piece[i].color == "black" && whitesTurn == false)
                        {
                            posibleMoves = Piece.queenMoveOptions(piece, piece[i]);
                            drawMoveOptions(posibleMoves);
                            selectedPiece = new Point(piece[i].x, piece[i].y);
                            borderselectedpiece(selectedPiece);
                        }
                        else
                        {
                            selectedPiece = new Point(-1, -1);
                        }
                    }
                }
            }
        }

        private void btnStartNewGame_Click(object sender, EventArgs e)
        {
            piece.Clear();
            whitesTurn = true;
            Piece.whiteCanCastle = true;
            piece.Add(new Piece(0, 1, "black", "pawn"));
            piece.Add(new Piece(1, 1, "black", "pawn"));
            piece.Add(new Piece(2, 1, "black", "pawn"));
            piece.Add(new Piece(3, 1, "black", "pawn"));
            piece.Add(new Piece(4, 1, "black", "pawn"));
            piece.Add(new Piece(5, 1, "black", "pawn"));
            piece.Add(new Piece(6, 1, "black", "pawn"));
            piece.Add(new Piece(7, 1, "black", "pawn"));

            piece.Add(new Piece(1, 0, "black", "knight"));
            piece.Add(new Piece(6, 0, "black", "knight"));

            piece.Add(new Piece(2, 0, "black", "bishop"));  // 10
            piece.Add(new Piece(5, 0, "black", "bishop"));

            piece.Add(new Piece(0, 0, "black", "rook"));
            piece.Add(new Piece(7, 0, "black", "rook"));

            piece.Add(new Piece(3, 0, "black", "queen"));
            piece.Add(new Piece(4, 0, "black", "king"));    // 15

            piece.Add(new Piece(0, 6, "white", "pawn"));
            piece.Add(new Piece(1, 6, "white", "pawn"));
            piece.Add(new Piece(2, 6, "white", "pawn"));
            piece.Add(new Piece(3, 6, "white", "pawn"));
            piece.Add(new Piece(4, 6, "white", "pawn"));    // 20
            piece.Add(new Piece(5, 6, "white", "pawn"));
            piece.Add(new Piece(6, 6, "white", "pawn"));
            piece.Add(new Piece(7, 6, "white", "pawn"));

            piece.Add(new Piece(1, 7, "white", "knight"));
            piece.Add(new Piece(6, 7, "white", "knight"));

            piece.Add(new Piece(2, 7, "white", "bishop"));
            piece.Add(new Piece(5, 7, "white", "bishop"));

            piece.Add(new Piece(0, 7, "white", "rook"));
            piece.Add(new Piece(7, 7, "white", "rook"));

            piece.Add(new Piece(3, 7, "white", "queen"));
            piece.Add(new Piece(4, 7, "white", "king"));
            drawGame();
        }

        private void drawGame()
        {
            drawGameBoard();
            drawGamePieces();
        }
        private void drawGameBoard()
        {
            g = pnlGameBoard.CreateGraphics();
            blackBrush = new SolidBrush(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            blueBrush = new SolidBrush(Color.Blue);
            redBrush = new SolidBrush(Color.Red);
            yellowPen = new Pen(Color.Yellow, 5);
            blackPen = new Pen(Color.Black, 2);
            whitePen = new Pen(Color.White, 2);
            greenBrush = new SolidBrush(Color.Green);
            int xStart = 0;
            int yStart = 0;
            int j = 1;
            for (int i = 1; i < 65; i++)
            {
                if (j % 2 == 0) g.FillRectangle(redBrush, xStart, yStart, 50, 50);
                if (j % 2 != 0) g.FillRectangle(blueBrush, xStart, yStart, 50, 50);
                xStart = xStart + 50;
                j++;
                if (i % 8 == 0)
                {
                    yStart = yStart + 50;
                    xStart = 0;
                    j++;
                }
            }
        }

        private void drawGamePieces()
        {

            for (int i = 0; i < 32; i++)
            {
                int xLocation = piece[i].x * 50;
                int yLocation = piece[i].y * 50;
                if (piece[i].name == "pawn")
                {
                    drawPawns(piece[i], xLocation, yLocation);
                }
                if (piece[i].name == "rook")
                {
                    drawRooks(piece[i], xLocation, yLocation);
                }
                if (piece[i].name == "bishop")
                {
                    drawBishops(piece[i], xLocation, yLocation);
                }
                if (piece[i].name == "knight")
                {
                    drawKnight(piece[i], xLocation, yLocation);
                }
                if (piece[i].name == "king")
                {
                    drawKing(piece[i], xLocation, yLocation);
                }
                if (piece[i].name == "queen")
                {
                    drawQueen(piece[i], xLocation, yLocation);
                }

            }
        }
        private void drawMoveOptions(List<Point> moves)
        {
            for (int i = 0; i < moves.Count(); i++)
            {
                g.DrawRectangle(yellowPen, ((moves[i].X) * 50) + 3, ((moves[i].Y) * 50) + 3, 44, 44);
            }
        }
        private void borderselectedpiece(Point cord)
        {
            g.DrawRectangle(blackPen, (cord.X) * 50, (cord.Y) * 50, 50, 50);
        }
        private void killPiece(Point landingSpot)
        {
            for (int i = 0; i < piece.Count(); i++)
            {
                if (piece[i].x == landingSpot.X && piece[i].y == landingSpot.Y)
                {
                    piece[i].x = 10;
                    piece[i].y = 8;
                }
            }
        }
        private void checkIfWhiteCastled(Point newLocation)
        {
            if (piece[31].x - 3 == newLocation.X) piece[28].x = piece[28].x + 2;
            if (piece[31].x + 2 == newLocation.X) piece[29].x = piece[29].x - 2;
        }
        private void checkIfBlackCastled(Point newLocation)
        {
            if (piece[15].x - 3 == newLocation.X) piece[12].x = piece[12].x + 2;
            if (piece[15].x + 2 == newLocation.X) piece[13].x = piece[13].x - 2;
        }

        private void drawRooks(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 7, py + 6);
            Point p2 = new Point(px + 14, py + 6);
            Point p3 = new Point(px + 14, py + 11);
            Point p4 = new Point(px + 17, py + 11);
            Point p5 = new Point(px + 17, py + 6);
            Point p6 = new Point(px + 23, py + 6);
            Point p7 = new Point(px + 23, py + 14);
            Point p8 = new Point(px + 26, py + 14);
            Point p9 = new Point(px + 26, py + 6);
            Point p10 = new Point(px + 32, py + 6);
            Point p11 = new Point(px + 32, py + 11);
            Point p12 = new Point(px + 35, py + 11);
            Point p13 = new Point(px + 35, py + 6);
            Point p14 = new Point(px + 42, py + 6);
            Point p15 = new Point(px + 42, py + 8);
            Point p16 = new Point(px + 34, py + 16);
            Point p17 = new Point(px + 34, py + 32);
            Point p18 = new Point(px + 45, py + 43);
            Point p19 = new Point(px + 4, py + 43);
            Point p20 = new Point(px + 15, py + 32);
            Point p21 = new Point(px + 15, py + 16);
            Point p22 = new Point(px + 7, py + 8);
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
        }
        private void drawPawns(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 13, py + 11);
            Point p2 = new Point(px + 36, py + 11);
            Point p3 = new Point(px + 36, py + 22);
            Point p4 = new Point(px + 30, py + 16);
            Point p5 = new Point(px + 30, py + 29);
            Point p6 = new Point(px + 38, py + 37);
            Point p7 = new Point(px + 41, py + 34);
            Point p8 = new Point(px + 41, py + 43);
            Point p9 = new Point(px + 8, py + 43);
            Point p10 = new Point(px + 8, py + 34);
            Point p11 = new Point(px + 11, py + 37);
            Point p12 = new Point(px + 19, py + 29);
            Point p13 = new Point(px + 19, py + 15);
            Point p14 = new Point(px + 13, py + 21);
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
        }
        private void drawBishops(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 25, py + 2);
            Point p2 = new Point(px + 33, py + 20);
            Point p3 = new Point(px + 33, py + 25);
            Point p4 = new Point(px + 31, py + 27);
            Point p5 = new Point(px + 31, py + 30);
            Point p6 = new Point(px + 44, py + 43);
            Point p7 = new Point(px + 5, py + 43);
            Point p8 = new Point(px + 18, py + 30);
            Point p9 = new Point(px + 18, py + 27);
            Point p10 = new Point(px + 16, py + 25);
            Point p11 = new Point(px + 16, py + 20);
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
        }
        private void drawKnight(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 17, py + 5);
            Point p2 = new Point(px + 28, py + 5);
            Point p3 = new Point(px + 35, py + 12);
            Point p4 = new Point(px + 31, py + 12);
            Point p5 = new Point(px + 35, py + 16);
            Point p6 = new Point(px + 31, py + 16);
            Point p7 = new Point(px + 35, py + 20);
            Point p8 = new Point(px + 31, py + 20);
            Point p9 = new Point(px + 35, py + 24);
            Point p10 = new Point(px + 30, py + 24);
            Point p11 = new Point(px + 30, py + 30);
            Point p12 = new Point(px + 45, py + 45);
            Point p13 = new Point(px + 4, py + 45);
            Point p14 = new Point(px + 19, py + 30);
            Point p15 = new Point(px + 19, py + 19);
            Point p16 = new Point(px + 11, py + 23);
            Point p17 = new Point(px + 5, py + 23);
            Point p18 = new Point(px + 5, py + 17);
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
            Point p19 = new Point(px + 18, py + 9);
            Point p20 = new Point(px + 18, py + 14);
            Point p21 = new Point(px + 13, py + 14);
            Point[] theKnightEye = { p19, p20, p21 };
            if (thePiece.color == "black") g.FillPolygon(whiteBrush, theKnightEye);
            if (thePiece.color == "white") g.FillPolygon(blackBrush, theKnightEye);

        }
        private void drawQueen(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 6, py + 3);
            Point p2 = new Point(px + 13, py + 7);
            Point p3 = new Point(px + 14, py + 3);
            Point p4 = new Point(px + 16, py + 9);
            Point p5 = new Point(px + 19, py + 3);
            Point p6 = new Point(px + 21, py + 9);
            Point p7 = new Point(px + 25, py + 3);
            Point p8 = new Point(px + 28, py + 9);
            Point p9 = new Point(px + 30, py + 3);
            Point p10 = new Point(px + 33, py + 9);
            Point p11 = new Point(px + 35, py + 3);
            Point p12 = new Point(px + 37, py + 7);
            Point p13 = new Point(px + 43, py + 3);
            Point p14 = new Point(px + 32, py + 14);
            Point p15 = new Point(px + 32, py + 32);
            Point p16 = new Point(px + 45, py + 45);
            Point p17 = new Point(px + 4, py + 45);
            Point p18 = new Point(px + 17, py + 32);
            Point p19 = new Point(px + 17, py + 14);
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
        }
        private void drawKing(Piece thePiece, int px, int py)
        {
            Point p1 = new Point(px + 21, py + 3);
            Point p2 = new Point(px + 28, py + 3);
            Point p3 = new Point(px + 28, py + 7);
            Point p4 = new Point(px + 32, py + 7);
            Point p5 = new Point(px + 32, py + 12);
            Point p6 = new Point(px + 28, py + 12);
            Point p7 = new Point(px + 28, py + 28);
            Point p8 = new Point(px + 45, py + 45);
            Point p9 = new Point(px + 4, py + 45);
            Point p10 = new Point(px + 21, py + 28);
            Point p11 = new Point(px + 21, py + 13);
            Point p12 = new Point(px + 17, py + 12);
            Point p13 = new Point(px + 17, py + 7);
            Point p14 = new Point(px + 21, py + 7);     
            Point[] thePoints = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 };
            if (thePiece.color == "black") g.DrawPolygon(whitePen, thePoints);
            if (thePiece.color == "black") g.FillPolygon(blackBrush, thePoints);
            if (thePiece.color == "white") g.DrawPolygon(blackPen, thePoints);
            if (thePiece.color == "white") g.FillPolygon(whiteBrush, thePoints);
        }
    }
}


