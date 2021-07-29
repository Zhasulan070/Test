<template>
  <div class="box" :class="[`box--${color}`]">
    <div class="box__title">
      <slot name="title"/>
    </div>
    <div class="box__content">
      <VuePerfectScrollbar class="scroll">
        <slot/>
      </VuePerfectScrollbar>
    </div>
  </div>
</template>
<script>
import VuePerfectScrollbar from "vue-perfect-scrollbar";
export default {
  props: {
    color: {
      type: String,
      default: 'blue'
    }
  },
  components: {
    VuePerfectScrollbar
  }
}
</script>
<style lang="scss" scoped>

.scroll {
  height: 400px;
  overflow: auto;
}
.box {
  padding: 18px 32px;
  border-radius: 40px;
  width: 100%;
  height: 100%;

  &--blue {
    background: #EEFAFD;
  }

  &--pink {
    background: #FDEEEE;
  }

  &--green {
    background: #F2FDEE;
  }

  &__title {
    font-style: normal;
    font-weight: 600;
    font-size: 20px;
    line-height: 24px;
    color: #000000;
    margin-bottom: 50px;
  }
}
</style>
