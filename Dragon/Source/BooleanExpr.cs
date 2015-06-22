﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon
{
    public class Constant : Expr
    {
        public Constant(Token tok, Dragon.Type type)
            : base(tok,type)
        { }

        public Constant(int i)
            : base(new Num(i), Dragon.Type.Int)
        { }

        public static readonly Constant
            True = new Constant(Word.True, Dragon.Type.Bool),
            False = new Constant(Word.False, Dragon.Type.Bool);

        public override void Jumping(int t, int f)
        {
            if (this == Constant.True && t != 0)
                this.Emit("goto L" + t);
            else if(this == Constant.False && f != 0)
                this.Emit("goto L" + f);
        }
    }


    public class Logical : Expr
    {
        public Expr LhsExpr, RhsExpr;

        public Logical(Token tok, Expr lhs, Expr rhs)
            : base(tok, null)
        {
            this.LhsExpr = lhs;
            this.RhsExpr = rhs;
            if (null == this.Check(this.LhsExpr.Type, this.RhsExpr.Type))
                this.Error("type error");
        }

        public Dragon.Type Check(Dragon.Type lhs, Dragon.Type rhs)
        {
            if (lhs == Dragon.Type.Bool && rhs == Dragon.Type.Bool) 
                return Dragon.Type.Bool;
            return null;
        }

        public override Expr Gen()
        {
            int f = this.NewLable();
            int a = this.NewLable();
            Temp temp = new Temp(this.Type);
            this.Jumping(0, f);
            this.Emit(temp.ToString() + " = true");
            this.Emit("goto L" + a);
            this.EmitLabel(f);
            this.Emit(temp.ToString() + " = false");
            this.EmitLabel(a);
            return temp;
        }

        public override string ToString()
        {
            return this.LhsExpr.ToString() + " " + this.Op.ToString() + " " + this.RhsExpr.ToString();
        }
    }


    public class Or : Logical
    {
        public Or(Token tok, Expr lhs, Expr rhs)
            : base(tok, lhs, rhs)
        { }

        public override void Jumping(int t, int f)
        {
            int label = t != 0 ? t : this.NewLable();
            this.LhsExpr.Jumping(label, 0);
            this.RhsExpr.Jumping(t, f);
            if (t == 0)
                this.EmitLabel(label);
        }
    }
}
