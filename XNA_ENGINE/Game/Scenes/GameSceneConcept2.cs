﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNA_ENGINE;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using XNA_ENGINE.Engine;
using XNA_ENGINE.Engine.Scenegraph;
using XNA_ENGINE.Engine.Objects;

using XNA_ENGINE.Engine.Helpers;

using XNA_ENGINE.Game.Objects;

using IP2_Xna_Template.Objects;
using Microsoft.Xna.Framework.Media;
using XNA_ENGINE.Game.Scenes;

using XNA_ENGINE.Game.Objects.Concept2;

namespace XNA_ENGINE.Game
{
    public class GameSceneConcept2 : GameScene
    {
        enum PlayerInput
        {
            ClickTile
        }

        private const int GRID_ROW_LENGTH = 30;
        private const int GRID_COLUMN_LENGTH = 30;
        private const int GRID_OFFSET = 25;
        private const int SCREEN_OFFSET_HORIZONTAL = 50;
        private const int SCREEN_OFFSET_VERTICAL = 50;


      //  private GridTile[][] m_GridField = new GridTile[GRID_ROW_LENGTH][];

        private List<List<GridTile>> m_GridField;

        private ContentManager Content;
        private InputManager m_InputManager;



        public GameSceneConcept2(ContentManager content)
            : base("GameSceneConcept2")
        {
            //CONTENT
            Content = content;

            //INPUT
            m_InputManager = new InputManager();

            InputAction Click = new InputAction((int)PlayerInput.ClickTile, TriggerState.Pressed);
            Click.MouseButton = MouseButtons.LeftButton;
            Click.GamePadButton = Buttons.X;

            m_InputManager.MapAction(Click);

            m_GridField = new List<List<GridTile>>();

            //GENERATE GRIDFIELD
            for (int i = 0; i < GRID_ROW_LENGTH; i++)
            {
                List<GridTile> tempList = new List<GridTile>();
                for (int j = 0; j < GRID_COLUMN_LENGTH; j++)
                {
                    tempList.Add(new GridTile(GridTile.TileType.Inactive, new Vector2((i * GRID_OFFSET) + SCREEN_OFFSET_HORIZONTAL, (j * GRID_OFFSET) + SCREEN_OFFSET_VERTICAL)));
                }
                m_GridField.Add(tempList);
            }
        }

        public override void Initialize()
        {
            // Add Interaction Scene for later use
            // -------------------------------------
            var interactionScene = new InteractionScene(Content);
            SceneManager.AddGameScene(interactionScene);
            //interactionScene.Initialize(1, 3);
            //SceneManager.SetActiveScene("InteractionScene");

            //TILES
            foreach (var gridTileList in m_GridField)
            {
                foreach (var gridTile in gridTileList)
                {
                    gridTile.Initialize();
                    AddSceneObject(gridTile.GetSprite(0));
                    AddSceneObject(gridTile.GetSprite(1));
                    AddSceneObject(gridTile.GetSprite(2));
                    AddSceneObject(gridTile.GetSprite(3));
                    AddSceneObject(gridTile.GetSprite(4)); 
                    AddSceneObject(gridTile.GetSprite(5));
                    AddSceneObject(gridTile.GetSprite(6));
                    AddSceneObject(gridTile.GetSprite(7));
                    AddSceneObject(gridTile.GetSprite(8));
                }
            }

            InitGrid();


            base.Initialize();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
        }

        public override void Update(RenderContext renderContext)
        {
            //INPUT
            m_InputManager.Update();
            
            //TILES
            Vector2 mousePos = new Vector2(renderContext.Input.CurrentMouseState.X,renderContext.Input.CurrentMouseState.Y);

            foreach (var gridTileList in m_GridField)
            {
                foreach (var gridTile in gridTileList)
                {
                    gridTile.Update();
                    if (m_InputManager.GetAction((int)PlayerInput.ClickTile).IsTriggered && GridHitTest(gridTile.GetPosition(),mousePos) )
                    {
                        //gridTile.SetTileType(GridTile.TileType.Normal);
                        gridTile.SetSelector(true);

                        int rowIndex = ((int)gridTile.GetPosition().Y-SCREEN_OFFSET_VERTICAL)/GRID_OFFSET;
                        int columnIndex = ((int)gridTile.GetPosition().X - SCREEN_OFFSET_HORIZONTAL) / GRID_OFFSET; ;
                        System.Diagnostics.Trace.WriteLine(" m_GridField[" + columnIndex + "]" + "[" + rowIndex + "].SetTileType(GridTile.TileType.Normal);");
                    }
                }
            }



            base.Update(renderContext);
        }

        public override void Draw2D(RenderContext renderContext, bool drawBefore3D)
        {
            base.Draw2D(renderContext, drawBefore3D);
        }

        public override void Draw3D(RenderContext renderContext)
        {
            base.Draw3D(renderContext);
        }

        private bool GridHitTest(Vector2 pos, Vector2 mousePos)
        {

            if (pos.X > mousePos.X) return false;
            if (pos.Y > mousePos.Y) return false;
            if (pos.X + GRID_OFFSET < mousePos.X) return false;
            if (pos.Y + GRID_OFFSET < mousePos.Y) return false;
            return true;
        }

        private void InitGrid()
        {
            m_GridField[11][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[20][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][11].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][4].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][5].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][3].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[15][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][26].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[22][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[21][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[14][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[19][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[17][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[16][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[10][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[12][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[13][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][16].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][17].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][19].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][6].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][10].SetTileType(GridTile.TileType.Normal);
            m_GridField[27][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[27][8].SetTileType(GridTile.TileType.Normal);
            m_GridField[26][9].SetTileType(GridTile.TileType.Normal);
            m_GridField[27][7].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[6][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[4][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[5][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[5][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[5][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[5][15].SetTileType(GridTile.TileType.Normal);
            m_GridField[4][14].SetTileType(GridTile.TileType.Normal);
            m_GridField[4][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[4][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[5][12].SetTileType(GridTile.TileType.Normal);
            m_GridField[4][13].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[9][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][23].SetTileType(GridTile.TileType.Normal);
            m_GridField[8][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][21].SetTileType(GridTile.TileType.Normal);
            m_GridField[7][20].SetTileType(GridTile.TileType.Normal);
            m_GridField[11][18].SetTileType(GridTile.TileType.Normal);
            m_GridField[18][22].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][25].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][24].SetTileType(GridTile.TileType.Normal);
            m_GridField[24][26].SetTileType(GridTile.TileType.Normal);
            m_GridField[23][26].SetTileType(GridTile.TileType.Normal);
            m_GridField[25][26].SetTileType(GridTile.TileType.Normal);


            m_GridField[14][11].SetSettlement(GridTile.Settlement.Green);
            m_GridField[9][3].SetSettlement(GridTile.Settlement.Red);
            m_GridField[12][24].SetSettlement(GridTile.Settlement.Blue);
            m_GridField[24][25].SetSettlement(GridTile.Settlement.Yellow);

        }
    }

}
