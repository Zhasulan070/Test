<template>
    <router-link class="sidebar-item" :to="item.to" active-class="active" tag="div">
        <div class="sidebar-item__icon">
            <svg>
                <use :xlink:href="require('@/assets/icons/sprite.svg') + '#' + item.icon"></use>
            </svg>
        </div>
        <div class="sidebar-item__text">{{item.text}}</div>
    </router-link>
</template>
<script>
export default {
    props: {
        item: {
            type: Object,
            default: () => {}
        }
    }
}
</script>
<style lang="scss" scoped>
    //.sidebar-item{
    //    width: 100%;
    //    border-radius: 5px;
    //    padding:7px;
    //    margin-bottom: 3px;
    //    cursor: pointer;
    //
    //    &.active{
    //        background:#DFF5FC;
    //    }
    //
    //    &__icon{
    //        width: 40px;
    //        height: 40px;
    //        padding: 24px 16px;
    //        background: #acb7c6;
    //        border-radius: 8px;
    //
    //        svg{
    //            width: 100%;
    //            height: 100%;
    //            object-fit: cover;
    //            object-position: center;
    //        }
    //    }
    //
    //    &__text{
    //      font-weight: 600;
    //      font-size: 8px;
    //      line-height: 11px;
    //      color: #FFFFFF;
    //      text-align: center;
    //      margin-top: 4px;
    //    }
    //}

    .sidebar-item{
        width: 100px;
        height: 100px;
        background: #c3eff5;
        border-radius: 8px;
        padding: 22px 17px;
        display: flex;
        flex-direction: column;
        align-items: center;
        margin:0 auto;
      &.active{
        background: #81d4ee;
      }

      &__icon{
        width: 40px;
        height: 40px;


        svg{
          width: 100%;
          height: 100%;
          object-fit: cover;
          object-position: center;
          fill: #fff;
        }
      }

      &__text{
        font-weight: 400;
        font-size: 12px;
        line-height: 11px;
        color: #FFFFFF;
        margin-top: 4px;
        text-align: center;
      }
    }
</style>
