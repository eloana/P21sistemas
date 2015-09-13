﻿#region Copyright © 2015 Couchcoding

// File:    OptionPanelGeneral.cs
// Package: Logbert
// Project: Logbert
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 Couchcoding
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System.Drawing;
using System.Windows.Forms;

using Com.Couchcoding.Logbert.Helper;
using Com.Couchcoding.Logbert.Properties;

namespace Com.Couchcoding.Logbert.Controls.OptionPanels
{
  /// <summary>
  /// Implements a <see cref="IOptionPanel"/> for general application settings.
  /// </summary>
  public partial class OptionPanelGeneral : OptionPanelBase
  {
    #region Public Properties

    /// <summary>
    /// Gets the name of the <see cref="IOptionPanel"/> <see cref="System.Windows.Forms.Control"/>.
    /// </summary>
    public override string PanelName
    {
      get
      {
        return Resources.strOptionPanelGeneral;
      }
    }

    /// <summary>
    /// Gets the <see cref="System.Drawing.Image"/> to display left of the <see cref="IOptionPanel"/> name.
    /// </summary>
    public override Image Image
    {
      get
      {
        return Resources.properties_16xLG;
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the ButtonClick event of the timestamp help <see cref="Button"/>.
    /// </summary>
    private void TxtTimestampFormatButtonClick(object sender, System.EventArgs e)
    {
      Control btnTimestamp = sender as Control;

      if (btnTimestamp != null)
      {
        mnuTimestamp.Show(
            btnTimestamp
          , new Point(btnTimestamp.Width, btnTimestamp.Height));
      }
    }

    /// <summary>
    /// Handles the Click event of a timestamp help <see cref="MenuItem"/>.
    /// </summary>
    private void MnuTimestampClick(object sender, System.EventArgs e)
    {
      MenuItem mnuCtrl = sender as MenuItem;

      if (mnuCtrl != null && mnuCtrl.Tag != null)
      {
        txtTimestampFormat.SelectedText = mnuCtrl.Tag.ToString();
      }
    }

    /// <summary>
    /// Handles the Click event of a timestamp preset <see cref="MenuItem"/>.
    /// </summary>
    private void MnuTimestampPresetClick(object sender, System.EventArgs e)
    {
      MenuItem mnuCtrl = sender as MenuItem;

      if (mnuCtrl != null && mnuCtrl.Tag != null)
      {
        txtTimestampFormat.Text = mnuCtrl.Tag.ToString();
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Method will be called before the <see cref="IOptionPanel"/> is shown first.
    /// </summary>
    public override void InitializeControl()
    {
      nudUpdateRate.Value             = Settings.Default.UiRefreshIntervalMs;
      txtTimestampFormat.Text         = Settings.Default.TimestampFormat;
      chkAutoFollow.Checked           = Settings.Default.LogWndAutoScrollOnLastMessageSelect;
      chkAllowOnlyOneInstance.Checked = Settings.Default.FrmMainAllowOnlyOneInstance;
    }

    /// <summary>
    /// Tells the <see cref="IOptionPanel"/> to save the new settings.
    /// </summary>
    public override void SaveSettings()
    {
      using (new WaitCursor(Cursors.Default, Settings.Default.WaitCursorTimeout))
      {
        Settings.Default.UiRefreshIntervalMs                 = (int)nudUpdateRate.Value;
        Settings.Default.TimestampFormat                     = txtTimestampFormat.Text;
        Settings.Default.LogWndAutoScrollOnLastMessageSelect = chkAutoFollow.Checked;
        Settings.Default.FrmMainAllowOnlyOneInstance         = chkAllowOnlyOneInstance.Checked;

        Settings.Default.SaveSettings();
      }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new instance of the <see cref="OptionPanelGeneral"/>.
    /// </summary>
    public OptionPanelGeneral()
    {
      InitializeComponent();
    }

    #endregion
  }
}
