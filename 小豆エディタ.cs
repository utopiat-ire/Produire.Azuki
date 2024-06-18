using System;
using System.Collections.Generic;
using System.Text;
using Produire;
using System.Windows.Forms;
using Sgry.Azuki.WinForms;

namespace Produire.Azuki
{
	public class 小豆エディタ : AzukiControl, IProduireClass
	{

		public 小豆エディタ()
		{
		}

		#region 手順

		[自分("から")]
		public void コピーする()
		{
			Copy();
		}

		[自分("へ")]
		public void 貼り付ける()
		{
			Paste();
		}

		[自分("へ")]
		public void 切り取る()
		{
			Cut();
		}

		[自分("を"), 補語("元に"), 手順("戻す")]
		public void 元に戻す()
		{
			Undo();
		}

		[自分("を")]
		public void やり直す()
		{
			Redo();
		}

		#endregion

		#region 設定項目

		public bool 変更済み
		{
			get { return Document.IsDirty; }
			set { Document.IsDirty = value; }
		}
		public int 選択開始位置
		{
			get
			{
				int start, end;
				Document.GetSelection(out start, out end);
				return start;
			}
			set
			{
				Document.SetSelection(value, value);
			}
		}
		public int 選択文字数
		{
			get
			{
				int start, end;
				Document.GetSelection(out start, out end);
				return end - start;
			}
			set
			{
				int start, end;
				Document.GetSelection(out start, out end);
				Document.SetSelection(start, start + value);
			}
		}
		public string 選択内容
		{
			get
			{
				int start, end;
				Document.GetSelection(out start, out end);
				return Document.GetTextInRange(start, end);
			}
		}
		public bool 読み取り専用
		{
			get { return Document.IsReadOnly; }
			set { Document.IsReadOnly = value; }
		}
		public System.Drawing.Color 文字色
		{
			get { return ForeColor; }
			set { ForeColor = value; }
		}
		public int 文字数
		{
			get { return Document.Length; }
		}
		public bool 戻せる
		{
			get { return CanUndo; }
		}
		public bool やり直せる
		{
			get { return CanRedo; }
		}

		#endregion

		#region イベント手順

		#endregion
	}
}
