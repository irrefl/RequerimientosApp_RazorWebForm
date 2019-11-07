﻿using Backend.Infrastructura;
using Backend.Infrastructura.Entities;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend.AdministradorPages
{
    public partial class EquipoProgramadores : System.Web.UI.Page
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public EquipoProgramadores() { }
        public EquipoProgramadores(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string tipoDeAsignacion = ModosDeAsignacion.SelectedItem.Text;
                RequerimientosGridView.DataSource = _unitOfWork.Programadores.GetAll();
                RequerimientosGridView.DataBind();

            }
        }

        protected void ModosDeAsignacion_TextChanged(object sender, EventArgs e)
        {

            BindGriwView(RequerimientosGridView, _unitOfWork.Programadores.GetAll());
        }

        public void BindGriwView(GridView grid, object dataSource)
        {
            grid.DataSource = dataSource;
            grid.DataBind();
        }

        protected void RequerimientosGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            idGrid.DataSource = _unitOfWork.Requerimientos.ObtenerTiposRequerimientos();
            idGrid.DataBind();
            /*
            string s = "";
            for (int i  = 0; i <  RequerimientosGridView.Rows[e.NewSelectedIndex].Cells.Count; i++)
            {
                s += RequerimientosGridView.Rows[e.NewSelectedIndex].Cells[i].Text;
            }

            mensaje.Text = s;
            */

            //Response.Write("<script>window.open('http://localhost:54713/Brochures/dummy.pdf','_blank');</script>");
            //Response.Write("<script>window.open('http://localhost:54713/Brochures/dummy.pdf','_blank');</script>");

        }
    }
}